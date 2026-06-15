string authors = "John,Jane,Bob,Alice";
string[] authorsArray = authors.Split(",");
string authorsV2= String.Join( "|", authorsArray);
Console.WriteLine(authorsV2);


