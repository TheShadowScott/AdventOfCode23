// Part 1
int[] times = [62, 73, 75,65];
int[] distances = [644, 1023, 1240, 1023];

int[] possibilities1 = [0,0,0,0];

for (int i = 0; i < 4; i++)
{
    for (int j = 0; j <= times[i]; j++)
    {
        int travelTime = times[i] - j;
        int travelDistance = travelTime * j;
        if (travelDistance > distances[i])
            possibilities1[i]++;
    }
}

Console.WriteLine(possibilities1.Aggregate(1, (x, y) => x * y));

// Part 2
long time = 62737565;
long distance = 644102312401023;
long possibilities = 0;
for (long j = 0; j <= time; j++)
{
    long travelTime = time - j;
    long travelDistance = travelTime * j;
    if (travelDistance > distance)
        possibilities++;
}
Console.WriteLine(possibilities);