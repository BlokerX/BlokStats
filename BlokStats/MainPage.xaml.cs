namespace BlokStats
{
   public partial class MainPage : ContentPage
    {
        private SkillHexagonDrawable _hexagonDrawable;
        private float[] _stats = [0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f];
        private Color _hexagonColor = Colors.Blue;  // Domyślny kolor wykresu

        public MainPage()
        {
            InitializeComponent();
            _hexagonDrawable = new SkillHexagonDrawable(
                new string[] { "P1", "P2", "P3", "P4", "P5", "P6" },
                new List<float[]> { _stats },
                new List<Color> { _hexagonColor }
            );
            HexagonView.Drawable = _hexagonDrawable;
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == Slider1) _stats[0] = (float)e.NewValue;
            else if (sender == Slider2) _stats[1] = (float)e.NewValue;
            else if (sender == Slider3) _stats[2] = (float)e.NewValue;
            else if (sender == Slider4) _stats[3] = (float)e.NewValue;
            else if (sender == Slider5) _stats[4] = (float)e.NewValue;
            else if (sender == Slider6) _stats[5] = (float)e.NewValue;

            HexagonView.Invalidate();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
                _stats[i] = 0.5f;

            Slider1.Value = Slider2.Value = Slider3.Value =
                Slider4.Value = Slider5.Value = Slider6.Value = 0.5;

            HexagonView.Invalidate();
        }

        // Funkcja obsługująca zmianę koloru wykresu
        private async void OnChangeColorClicked(object sender, EventArgs e)
        {
            // Utwórz listę kolorów z nazwami
            var colorOptions = new (string name, Color color)[]
            {
                ("Niebieski", Colors.Blue),
                ("Czerwony", Colors.Red),
                ("Żółty", Colors.Yellow),
                ("Zielony", Colors.Green),
                ("Pomarańczowy", Colors.Orange),
                ("Indygo", Colors.Indigo),
                ("Fioletowy", Colors.Purple),
                ("Biały", Colors.White),
                ("Czarny", Colors.Black)
            };

            // Wyświetl panel wyboru z kolorami
            string selectedColorName = await DisplayActionSheet("Wybierz kolor", "Anuluj", null,
                colorOptions.Select(option => option.name).ToArray());

            // Jeśli użytkownik anulował, zakończ
            if (selectedColorName == "Anuluj")
                return;

            // Znajdź wybrany kolor na podstawie nazwy
            var selectedColor = colorOptions.FirstOrDefault(option => option.name == selectedColorName).color;

            // Ustaw kolor wykresu na wybrany
            _hexagonColor = selectedColor;

            // Zaktualizuj wykres z nowym kolorem
            _hexagonDrawable = new SkillHexagonDrawable(
                new string[] { "P1", "P2", "P3", "P4", "P5", "P6" },
                new List<float[]> { _stats },
                new List<Color> { _hexagonColor }
            );
            HexagonView.Drawable = _hexagonDrawable;
            HexagonView.Invalidate();
        }

    }

}
