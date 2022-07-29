namespace ManubiaTask
{
    public sealed class Unit : Classifier
    {
        protected override string AttributeName => nameof(Unit);

        //use AttributeName with WEIGHT, LENGTH, CAPACITY suffix from Suffixes class to switch attributes
        //for example: UNIT_CAPACITY is ML
        //extract attributes from product's data

        //Hint: you can use regular expressions to get data (Regex class) - if you decide to use it, you should change UnitValueRegex from Regexes class
        //what is more, you can check https://regexr.com/ to verify if your patterns work 
    }
}
