namespace BlokStats
{
    public partial class MainPage : ContentPage
    {


        float[] stats1 = new float[] { 0.8f, 0.6f, 0.9f, 0.4f, 0.7f, 0.5f }; // Postać 1
        float[] stats2 = new float[] { 0.6f, 0.7f, 0.8f, 0.5f, 0.6f, 0.9f }; // Postać 2
        float[] stats3 = new float[] { 0.9f, 0.4f, 0.7f, 0.8f, 0.5f, 0.6f }; // Postać 3

        List<float[]> statsList;
        List<Color> colors = [Colors.Blue, Colors.Red, Colors.Yellow];

        string[] labels; // Nazwy umiejętności



        public MainPage()
        {
            InitializeComponent();

            statsList = [stats1, stats2, stats3];

            labels = ["Parametr 1", "Parametr 2", "Parametr 3", "Parametr 4", "Parametr 5", "Parametr 6"];

            HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);

        }

        private void Button_OnClicked(object? sender, EventArgs e)
        {
            for (int i = 0; i < statsList.Count; i++)
            {
                for (int j = 0; j < statsList[i].Length; j++)
                {
                    statsList[i][j] += 0.01f;
                }
            }
            HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
        }

        private void Button2_OnClicked(object? sender, EventArgs e)
        {
            for (int i = 0; i < statsList.Count; i++)
            {
                for (int j = 0; j < statsList[i].Length; j++)
                {
                    statsList[i][j] -= 0.01f;
                }
            }
            HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
        }

        #region Entries

        private void Entry11_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][0] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry12_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][1] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry13_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][2] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry14_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][3] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry15_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][4] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry16_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[0][5] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry21_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][0] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry22_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][1] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry23_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][2] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry24_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][3] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry25_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][4] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry26_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[1][5] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry31_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][0] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry32_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][1] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry33_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][2] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry34_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][3] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry35_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][4] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }

        private void Entry36_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (float.TryParse((sender as Entry)?.Text, out float value))
            {
                statsList[2][5] = value / 100f;
                HexagonView.Drawable = new SkillHexagonDrawable(labels, statsList, colors, true);
            }
        }


        #endregion
    }

}
