using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;
using Wintellect.PowerCollections;

namespace Events
{
    public class EventsMain
    {
        public static void Main(string[] args)
        {
            CommandExecutor executor = new CommandExecutor(new Calendar());
            StringBuilder buffer = new StringBuilder();
            string cmdMessage = "";

            while (true)
            {
                cmdMessage = executor.ExecuteCommand(Console.ReadLine());
                if (cmdMessage == "End")
                {
                    break;
                }

                buffer.Append(cmdMessage + "\n");
            }

            Console.Write(buffer.ToString());
        }
    }

    /// <summary>
    /// Event
    /// </summary>
    public class Event : IComparable
    {
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public Event(DateTime dateTime, string title, string location)
        {
            this.DateTime = dateTime;
            this.Title = title;
            this.Location = location;
        }

        public Event(DateTime dateTime, string title)
            : this(dateTime, title, "")
        {
        }

        public int CompareTo(object obj)
        {
            Event ev = obj as Event;

            int compareResult = this.DateTime.CompareTo(ev.DateTime);

            if (compareResult == 0)
            {
                compareResult = this.Title.CompareTo(ev.Title);
            }

            if (compareResult == 0)
            {
                compareResult = this.Location.CompareTo(ev.Location);
            }

            return compareResult;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0:yyyy-MM-ddTHH:mm:ss} | {1}", this.DateTime, this.Title);

            if (this.Location != "")
            {
                result.AppendFormat(" | {0}", this.Location);
            }

            return result.ToString();
        }
    }

    /// <summary>
    /// Calendar
    /// </summary>
    public class Calendar
    {
        private MultiDictionary<string, Event> byTitle;
        private OrderedMultiDictionary<DateTime, Event> byDate;

        public Calendar()
        {
            bool allowDuplicates = true;
            this.byTitle = new MultiDictionary<string, Event>(allowDuplicates);
            this.byDate = new OrderedMultiDictionary<DateTime, Event>(allowDuplicates);
        }

        public void AddEvent(DateTime dateTime, string title, string location)
        {
            Event newEvent = new Event(dateTime, title, location);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(dateTime, newEvent);
        }

        public void AddEvent(DateTime dateTime, string title)
        {
            Event newEvent = new Event(dateTime, title);
            this.byTitle.Add(title.ToLower(), newEvent);
            this.byDate.Add(dateTime, newEvent);
        }

        public int DeleteEvents(string title)
        {
            title = title.ToLowerInvariant();
            var deletedEvents = this.byTitle[title];
            int deletedEventsCount = deletedEvents.Count;

            foreach (var delEvent in deletedEvents)
            {
                this.byDate.Remove(delEvent.DateTime, delEvent);
            }

            this.byTitle.Remove(title);

            return deletedEventsCount;
        }

        public IEnumerable<Event> ListEvents(DateTime dateTime, int count)
        {
            var matchedCalendarEvents =
                from matchedEvent in this.byDate.RangeFrom(dateTime, true).Values
                select matchedEvent;

            var filteredEvents = matchedCalendarEvents.Take(count);

            return filteredEvents;
        }
    }

    public class CommandExecutor
    {
        private const string AddEvent = "AddEvent";
        private const string DeleteEvents = "DeleteEvents";
        private const string End = "End";
        private const string ListEvents = "ListEvents";
        private const string EventAdded = "Event added";
        private const string XEventsDeleted = "{0} events deleted";
        private const string NoEventsFound = "No events found";
        private const string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly CultureInfo culture = CultureInfo.InvariantCulture;

        private Calendar calendar;

        public CommandExecutor(Calendar calendar)
        {
            this.calendar = calendar;
        }

        public string ExecuteCommand(string command)
        {
            StringBuilder result = new StringBuilder();

            List<string> cmd = this.ParseCommand(command);

            string cmdName = cmd[0];
            switch (cmdName)
            {
                case AddEvent:
                    {
                        DateTime dateTime = this.ParseDateTime(cmd[1]);
                        string title = cmd[2];
                        if (cmd.Count == 4)
                        {
                            string location = cmd[3];
                            calendar.AddEvent(dateTime, title, location);
                        }
                        else
                        {
                            calendar.AddEvent(dateTime, title);
                        }

                        result.Append(EventAdded);
                        break;
                    }

                case DeleteEvents:
                    {
                        string title = cmd[1];
                        int count = calendar.DeleteEvents(title);
                        if (count != 0)
                        {
                            result.AppendFormat(XEventsDeleted, count);
                        }
                        else
                        {
                            result.Append(NoEventsFound);
                        }

                        break;
                    }

                case ListEvents:
                    {
                        DateTime dateTime = this.ParseDateTime(cmd[1]);
                        int count = int.Parse(cmd[2]);
                        var events = calendar.ListEvents(dateTime, count);

                        if (events.Count() != 0)
                        {
                            foreach (var ev in events)
                            {
                                result.AppendLine(ev.ToString());
                            }

                            result.Length--;
                        }
                        else
                        {
                            result.Append(NoEventsFound);
                        }

                        break;
                    }

                case End:
                    {
                        result.Append(End);
                        break;
                    }
            }

            return result.ToString();
        }

        public DateTime ParseDateTime(string dateTime)
        {
            return DateTime.ParseExact(dateTime, dateTimeFormat, culture);
        }

        public List<string> ParseCommand(string command)
        {
            List<string> commandAsStrings = new List<string>();

            if (command == "End")
            {
                commandAsStrings.Add(command);
            }
            else
            {
                int indexOfFirstSpace = command.IndexOf(' ');
                string commandName = command.Substring(0, indexOfFirstSpace);

                commandAsStrings.Add(commandName);

                string[] arguments = command.Substring(indexOfFirstSpace + 1).Split('|');

                for (int i = 0; i < arguments.Length; i++)
                {
                    commandAsStrings.Add(arguments[i].Trim());
                }
            }

            return commandAsStrings;
        }
    }
}