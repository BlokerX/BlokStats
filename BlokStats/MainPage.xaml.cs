namespace BlokStats
{
    public partial class MainPage : ContentPage
    {
        private SkillHexagonDrawable _hexagonDrawable;
        private List<float[]> _stats = new List<float[]>
        {
            new float[] { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f }, // Wykres 0
            new float[] { 0f, 0f, 0f, 0f, 0f, 0f }, // Wykres 1
            new float[] { 0f, 0f, 0f, 0f, 0f, 0f }  // Wykres 2
        };
        private List<Color> _hexagonColors = new List<Color> { Colors.Blue, Colors.Red, Colors.Green };  // Domyślne kolory wykresów
        private int _currentChartIndex = 0;  // Indeks aktywnego wykresu (domyślnie 0)

        public MainPage()
        {
            InitializeComponent();
            UpdateHexagonDrawable();
            UpdateSliders();

            ChartSwitchButton.Text = $"Przełącz wykres ({_currentChartIndex + 1})";
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            // Zmieniamy wartości w zależności od wybranego wykresu
            int selectedIndex = _currentChartIndex;

            if (sender == Slider1) _stats[selectedIndex][0] = (float)e.NewValue;
            else if (sender == Slider2) _stats[selectedIndex][1] = (float)e.NewValue;
            else if (sender == Slider3) _stats[selectedIndex][2] = (float)e.NewValue;
            else if (sender == Slider4) _stats[selectedIndex][3] = (float)e.NewValue;
            else if (sender == Slider5) _stats[selectedIndex][4] = (float)e.NewValue;
            else if (sender == Slider6) _stats[selectedIndex][5] = (float)e.NewValue;

            HexagonView.Invalidate();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            // Resetujemy wybrany wykres
            for (int i = 0; i < 6; i++)
                _stats[_currentChartIndex][i] = 0.5f;

            Slider1.Value = Slider2.Value = Slider3.Value =
                Slider4.Value = Slider5.Value = Slider6.Value = 0.5;

            HexagonView.Invalidate();
        }

        private void OnZeroGraphClicked(object sender, EventArgs e)
        {
            // Resetowanie wszystkich parametrów do wartości zerowych
            for (int i = 0; i < 6; i++)
                _stats[0][i] = 0;

            // Resetowanie wartości suwaków do 0
            Slider1.Value = Slider2.Value = Slider3.Value =
                Slider4.Value = Slider5.Value = Slider6.Value = 0;

            // Odświeżenie widoku
            HexagonView.Invalidate();
        }

        // Funkcja zmieniająca aktywny wykres
        private void OnChartSwitchClicked(object sender, EventArgs e)
        {
            _currentChartIndex = (_currentChartIndex + 1) % 3;  // Przełączanie między 0, 1, 2
            UpdateHexagonDrawable();
            UpdateSliders();  // Aktualizacja wartości suwaków

            ChartSwitchButton.Text = $"Przełącz wykres ({_currentChartIndex + 1})";
        }

        // Metoda, która ustawia wartości suwaków na podstawie aktywnego wykresu
        private void UpdateSliders()
        {
            // Pobieramy wartości suwaków z aktywnego wykresu
            var chartData = _stats[_currentChartIndex];

            Slider1.Value = chartData[0];
            Slider2.Value = chartData[1];
            Slider3.Value = chartData[2];
            Slider4.Value = chartData[3];
            Slider5.Value = chartData[4];
            Slider6.Value = chartData[5];
        }

        // Funkcja aktualizująca widok wykresu
        private void UpdateHexagonDrawable()
        {
            _hexagonDrawable = new SkillHexagonDrawable(
                new string[] { "P1", "P2", "P3", "P4", "P5", "P6" },
                _stats,
                _hexagonColors
            );
            HexagonView.Drawable = _hexagonDrawable;
            HexagonView.Invalidate();
        }

        // Funkcja obsługująca zmianę koloru wykresu
        private async void OnChangeColorClicked(object sender, EventArgs e)
        {
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

            string selectedColorName = await DisplayActionSheet("Wybierz kolor", "Anuluj", null,
                colorOptions.Select(option => option.name).ToArray());

            if (selectedColorName == "Anuluj")
                return;

            var selectedColor = colorOptions.FirstOrDefault(option => option.name == selectedColorName).color;

            _hexagonColors[_currentChartIndex] = selectedColor;
            UpdateHexagonDrawable();
        }
    }
}
