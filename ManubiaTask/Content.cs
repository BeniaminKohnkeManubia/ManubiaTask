namespace ManubiaTask
{
    public sealed class Content : Classifier
    {
        protected override string AttributeName => nameof(Content);

        //use AttributeName with WEIGHT, LENGTH, CAPACITY suffix from Suffixes class to switch attributes
        //for example: CONTENT_CAPACITY is 30
        //extract attributes from product's data

        //Hint: you can use regular expressions to get data (Regex class) - if you decide to use it, you should change UnitValueRegex from Regexes class
        //what is more, you can check https://regexr.com/ to verify if your patterns work 
    }
}
