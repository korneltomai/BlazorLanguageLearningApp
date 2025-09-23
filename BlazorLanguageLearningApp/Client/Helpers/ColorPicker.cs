﻿using System.Drawing;

namespace BlazorLanguageLearningApp.Client.Helpers;

public static class ColorPicker
{
    public static Color GetGradient(double percentage, Color Start, Color Center, Color End)
    {
        if (percentage < 0.5)
            return ColorInterp(Start, Center, percentage / 0.5);
        else if (percentage == 0.5)
            return Center;
        else
            return ColorInterp(Center, End, (percentage - 0.5) / 0.5);
    }

    private static int LinearInterp(int start, int end, double percentage) => start + (int)Math.Round(percentage * (end - start));

    private static Color ColorInterp(Color start, Color end, double percentage) =>
        Color.FromArgb(LinearInterp(start.A, end.A, percentage),
                       LinearInterp(start.R, end.R, percentage),
                       LinearInterp(start.G, end.G, percentage),
                       LinearInterp(start.B, end.B, percentage));
}
