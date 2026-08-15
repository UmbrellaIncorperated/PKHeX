using System.ComponentModel;

namespace PKHeX.Core;

/// <summary>
/// Settings for Legends: Z-A (<see cref="LumioseRNG"/> / <see cref="LumioseSolver"/>) origin seed recovery.
/// </summary>
/// <remarks>
/// These are surfaced separately from the rest of <see cref="LegalitySettings"/> because, unlike every other
/// toggle here, enabling them trades real wall-clock time (seconds to well over a minute per Pokémon) for a
/// guarantee that shiny/multi-roll Z-A encounters are still checked against their origin seed instead of being
/// skipped. Off by default for the same reason the rest of legality checking stays instant.
/// </remarks>
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class LumioseRngSettings
{
    [LocalizedDescription("ZA: Search for the origin seed of a 1-roll shiny encounter (Shiny.Random). Adds a small delay (up to a few seconds) per shiny checked, instead of skipping the seed check entirely.")]
    public bool SearchShiny1
    {
        get => LumioseSolver.SearchShiny1;
        set => LumioseSolver.SearchShiny1 = value;
    }

    [LocalizedDescription("ZA: Search for the origin seed of encounters with more than 1 shiny roll. Brute-forces an unknown 32-bit half of the 64-bit seed, so this can take well over a minute per Pokémon checked - only enable for deliberate spot-checks, not routine batch legality runs.")]
    public bool SearchShinyN
    {
        get => LumioseSolver.SearchShinyN;
        set => LumioseSolver.SearchShinyN = value;
    }
}
