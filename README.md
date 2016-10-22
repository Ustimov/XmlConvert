# XmlConvert

Wrapper around System.Xml.XmlSerializer for simple and concise converting C# objects (DTO, POCO) to XML representation and vice verse.
API inspired by JsonConvert from [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) library.
Designed for use with [ServiceStack](https://github.com/ServiceStack/ServiceStack) backend, but other applications are acceptable too.

NuGet: [Ustimov.Org.XmlConvert](https://www.nuget.org/packages/Ustimov.Org.XmlConvert).

## Features

* Support for object serialization/deserialization without namespaces

* Support for object serialization/deserialization with default namespace

* Support for object serialization/deserialization with default and custom namespaces

## How to use

Look [demo project](https://github.com/Ustimov/XmlConvert/blob/master/XmlConvertDemo/Program.cs) for full example.

### Serialization

```cs
var john = new Person { FirstName = "John", LastName = "Doe", Age = 45 };
Console.WriteLine(XmlConvert.SerializeObject(john));
```

### Deserialization
```cs
var xml = @"<ContactsResponse xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""
							  xmlns=""http://schemas.datacontract.org/2004/07/"">
			  <Contacts>
				<ContactModel>
				  <FullName>String</FullName>
				  <Id>0</Id>
				  <Image>String</Image>
				  <LastMessage>String</LastMessage>
				  <LastMessageDateTime>0001-01-01T00:00:00</LastMessageDateTime>
				</ContactModel>
			  </Contacts>
			</ContactsResponse>";

var contactsReponse = XmlConvert.DeserializeObject<ContactsResponse>(xml,
	"http://schemas.datacontract.org/2004/07/");
```

## License

The MIT License (MIT)
Copyright (c) 2016 Artem Ustimov

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.