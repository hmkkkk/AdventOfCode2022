// A - rock: 1pt
// B - paper: 2pts
// C - scissors: 3pts

// X - loss
// Y - draw
// Z - win

string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

int score = 0;

foreach (var line in data)
{
    var playerInputs = line.Split(' ');

    if (playerInputs[1] == "X") // loss scenario
    {
        // we have to choose a losing option, e.g.,
        // opponent chose rock (A) - we choose scissors so we get 3pts
        switch (playerInputs[0]) 
        {
            case "A": score += 3; break;
            case "B": score += 1; break;
            case "C": score += 2; break;
        }
    }
    else if (playerInputs[1] == "Y") // draw scenario
    {
        score += 3; // 3 pts for draw

        // we have to choose the same option as our opponent, e.g.,
        // opponent chose rock (A) - we choose rock as well so we get 1pt
        switch (playerInputs[0])
        {
            case "A": score += 1; break;
            case "B": score += 2; break;
            case "C": score += 3; break;
        }
    }
    else // win scenario
    {
        score += 6; // 6pts for win

        // we have to choose the a winning option, e.g.,
        // opponent chose rock (A) - we choose paper so we get 2pts
        switch (playerInputs[0])
        {
            case "A": score += 2; break;
            case "B": score += 3; break;
            case "C": score += 1; break;
        }
    }
}

Console.WriteLine(score);