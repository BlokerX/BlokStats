namespace BlokStats;

public class SkillHexagonDrawable : IDrawable
{
    // Labels:
    private string[] _labels = ["Parametr 1", "Parametr 2", "Parametr 3", "Parametr 4", "Parametr 5", "Parametr 6"]; // Nazwy umiejętności (6)

    // Graphs:
    private List<float[]> _statsList = new();
    private List<Color> _colors = new();

    // Properties:
    public bool Fill { get; set; } = true;
    public Color FillColor { get; set; } = Colors.Gray.WithAlpha(0.25f);
    public Color StrokeColor { get; set; } = Colors.Gray;
    public float StrokeSize { get; set; } = 4;
    public Color TextColor { get; set; } = Colors.Black;
    public float Padding { get; set; } = 10;

    public SkillHexagonDrawable(string[] labels, List<float[]> statsList, List<Color> colors, bool fill = false)
    {
        if (labels.Length != 6)
            throw new ArgumentException("Musisz podać dokładnie 6 nazw umiejętności.");

        if (statsList.Count != colors.Count)
            throw new ArgumentException("Liczba zestawów statystyk i kolorów musi być taka sama.");

        foreach (var stats in statsList)
        {
            if (stats.Length != 6)
                throw new ArgumentException("Każdy zestaw statystyk musi mieć dokładnie 6 wartości.");
        }

        _labels = labels;
        _statsList = statsList;
        _colors = colors;

        Fill = fill;
    }

    public SkillHexagonDrawable(string[] labels, List<float[]> statsList, List<Color> colors, Color strokeColor, float strokeSize, Color fillColor, bool fill = true) : this(labels, statsList, colors)
    {
        StrokeColor = strokeColor;
        StrokeSize = strokeSize;
        FillColor = fillColor;
        Fill = fill;
    }

    #region Drawing

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float centerX = dirtyRect.Width / 2;
        float centerY = dirtyRect.Height / 2;
        float radius = Math.Min(centerX, centerY) - Padding; // Promień heksagonu

        // Rysowanie przekątnych
        DrawDiagonals(canvas, centerX, centerY, radius, Colors.DarkGray, 1);

        // Rysowanie bazowego heksagonu
        DrawHexagon(canvas, centerX, centerY, radius, Colors.DarkSlateGray, Fill, StrokeSize);

        int stepsCount = 5;
        float radiusStep = radius / stepsCount;
        for (int i = 1; i < stepsCount; i++)
            // Rysowanie pomocniczych heksagonów
            DrawHexagon(canvas, centerX, centerY, radiusStep * i, Colors.Gray, false, 1);

        // Rysowanie wielu wykresów
        for (int i = 0; i < _statsList.Count; i++)
        {
            DrawSkillHexagon(canvas, centerX, centerY, radius, _statsList[i], _colors[i]);
        }

        // Rysowanie etykiet statystyk
        DrawLabels(canvas, centerX, centerY, radius, TextColor);


    }

    private void DrawHexagon(ICanvas canvas, float cx, float cy, float r, Color color, bool fill, float strokeSize)
    {
        var path = new PathF();
        for (int i = 0; i < 6; i++)
        {
            float angle = (float)(Math.PI / 3 * i); // Kąt dla każdego wierzchołka
            float x = cx + r * (float)Math.Cos(angle);
            float y = cy + r * (float)Math.Sin(angle);

            if (i == 0)
                path.MoveTo(x, y);
            else
                path.LineTo(x, y);
        }
        path.Close();

        canvas.StrokeColor = color;
        canvas.StrokeSize = strokeSize;
        if (fill)
        {
            canvas.FillColor = FillColor;
            canvas.FillPath(path);
        }
        canvas.DrawPath(path);
    }

    private void DrawDiagonals(ICanvas canvas, float cx, float cy, float r, Color color, float strokeSize)
    {
        canvas.StrokeColor = color;
        canvas.StrokeSize = strokeSize;

        for (int i = 0; i < 6; i++)
        {
            float angle = (float)(Math.PI / 3 * i);
            float x = cx + r * (float)Math.Cos(angle);
            float y = cy + r * (float)Math.Sin(angle);

            canvas.DrawLine(cx, cy, x, y);
        }
    }

    private void DrawSkillHexagon(ICanvas canvas, float cx, float cy, float r, float[] stats, Color color)
    {
        var path = new PathF();
        for (int i = 0; i < 6; i++)
        {
            float angle = (float)(Math.PI / 3 * i);
            float statR = r * stats[i]; // Skalowanie wierzchołka na podstawie wartości statystyki
            float x = cx + statR * (float)Math.Cos(angle);
            float y = cy + statR * (float)Math.Sin(angle);

            if (i == 0)
                path.MoveTo(x, y);
            else
                path.LineTo(x, y);
        }
        path.Close();

        canvas.FillColor = color.WithAlpha(0.5f);
        canvas.FillPath(path);
        canvas.StrokeColor = color;
        canvas.StrokeSize = 2;
        canvas.DrawPath(path);
    }

    private void DrawLabels(ICanvas canvas, float cx, float cy, float r, Color color)
    {
        for (int i = 0; i < 6; i++)
        {
            float angle = (float)(Math.PI / 3 * i);
            float x = cx + (r + 20) * (float)Math.Cos(angle);
            float y = cy + (r + 20) * (float)Math.Sin(angle);

            canvas.FontColor = color;
            canvas.FontSize = 14;
            canvas.DrawString(_labels[i], x, y, HorizontalAlignment.Center);
        }
    }

    #endregion
}