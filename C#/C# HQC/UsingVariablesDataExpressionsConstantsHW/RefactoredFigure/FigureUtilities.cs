using System;

namespace RefactoredFigure
{
    // I really don't get what this function does.
    // I mean - if we rotate the figure, the width and the height
    // shouldn't be changed, only the coordinates of the vertexes
    // of that figure (which are missing).
    // I will just leave it like that
    public static class FigureUtilities
    {
        public static Figure RotateFigure(Figure figure, double rotationAngle)
        {
            double cosOfRotationAngle = Math.Cos(rotationAngle);
            double sinOfRotationAngle = Math.Sin(rotationAngle);

            double newWidth = 
                (Math.Abs(cosOfRotationAngle) * figure.Width) + 
                (Math.Abs(sinOfRotationAngle) * figure.Height);
            double newHeight = 
                (Math.Abs(sinOfRotationAngle) * figure.Width) + 
                (Math.Abs(cosOfRotationAngle) * figure.Height);

            return new Figure(newWidth, newHeight);
        }
    }
}
