using System;
using System.Linq;
using Microsoft.AspNet.SignalR;
using System.Threading;
using Microsoft.AspNet.SignalR.Hubs;

namespace PingPongGame.Hubs
{
    [HubName("game")]
    public class PingPongHub : Hub
    {
        private Field field;
        private PlayerPad firstPlayerPad;
        private PlayerPad secondPlayerPad;
        private Ball ball;

        public Field Field
        {
            get
            {
                return this.field;
            }
            set
            {
                this.field = value;
            }
        }

        public PlayerPad FirstPlayerPad
        {
            get
            {
                return this.firstPlayerPad;
            }
            set
            {
                this.firstPlayerPad = value;
            }
        }

        public PlayerPad SecondPlayerPad
        {
            get
            {
                return this.secondPlayerPad;
            }
            set
            {
                this.secondPlayerPad = value;
            }
        }

        public Ball Ball
        {
            get
            {
                return this.ball;
            }
            set
            {
                this.ball = value;
            }
        }

        public void Hello()
        {
            Clients.All.hello();
        }

        public void JoinRoom(string roomName)
        {
            if (this.Clients.Group(roomName) == null)
            {
                this.Groups.Add(this.Context.ConnectionId, roomName);
            }
        }

        public void Init(int fieldWidth, int fieldHeight, int padSize)
        {
            this.field = new Field(fieldWidth, fieldHeight);

            this.firstPlayerPad =
                new PlayerPad(0, fieldHeight / 2 - padSize / 2, padSize);

            this.secondPlayerPad =
                new PlayerPad(fieldWidth - 1, fieldHeight / 2 - padSize / 2, padSize);

            this.ball =
                new Ball(fieldWidth / 2, fieldHeight / 2);
        }

        public void Run()
        {
            this.Clients.All.init();

            while (true)
            {
                // Move first player
                // Move second player
                // Move ball
                // Draw first player
                // Draw second player
                // Draw ball

                Thread.Sleep(50);
            }
        }
    }
}