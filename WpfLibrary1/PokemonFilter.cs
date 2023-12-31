namespace WpfLibrary1
{
    public abstract class PokemonFilter
    {
        public PokemonFilter()
        {
            
        }

        public virtual bool PassesFilter(Pokemon pokemon)
        {
            return true;
        }
    }

    public static class PokemonFilterBuilder
    {
        public static PokemonFilter BuildTypeFilter(Types typeOne, Types typeTwo, bool isMonoType = false)
        {
            return new TypeFilter()
                .WithTypes(typeOne, typeTwo)
                .MonotypesOnly(isMonoType);
        }
    }

    public class TypeFilter : PokemonFilter
    {
        public Types[]? TypesToFilter { get; set; }

        public override bool PassesFilter(Pokemon pokemon)
        {
            try
            {
                if (TypesToFilter is null || TypesToFilter.Length == 0)
                {
                    return true;
                }

                if (TypesToFilter[0] == Types.None && TypesToFilter[1] == Types.None && !IsMonotype)
                {
                    return true;
                }

                if (TypesToFilter[1] == Types.None || IsMonotype)
                {
                    return pokemon.IsOfType(TypesToFilter[0], IsMonotype);
                }

                var result = pokemon.IsOfType(TypesToFilter[0]) && pokemon.IsOfType(TypesToFilter[1]);
                return result;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception);
                return true;
            }
        }

        public bool IsMonotype { get; set; }
    }
    
    public static class TypeFilterExtensions
    {
        public static TypeFilter WithTypes(this TypeFilter filter, params Types[] types)
        {
            filter.TypesToFilter = new Types[types.Length];
            types.CopyTo(filter.TypesToFilter, 0);
            return filter;
        }

        public static TypeFilter MonotypesOnly(this TypeFilter filter, bool monotypesOnly)
        {
            filter.IsMonotype = monotypesOnly;
            return filter;
        }
    }
}
