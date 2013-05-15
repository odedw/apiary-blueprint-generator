#Apiary Blueprint Generator

Generate an Apiary blueprint from a .Net XML documentation file. Integrate into your deployment process and use Apiary's future API to upload the blueprint for a full solution.

##Usage

The blueprint generator is a command line application. It accepts the following parameters:
* Input file name (*Required*)                  : name of the input XML file
* Output file name (*Required*)                 : name of the output txt file
* API documentation title (*Required*)          : Title for the API documentation
* Host address (*Optional*)                     : host address for the real server
* API documentation description (*Optional*)    : description for the API
* Desired clasess namespace prefix (*Optional*) : the desired controllers namespace (all other documentation will be filtered out)

Example usage:
`..\..\..\ShoppingCartExample\bin\ShoppingCartExample.XML ShoppingCartExample.txt "Sample API v2" -d "Welcome to the our sample API documentation. All comments can be written in (support [Markdown](http://daringfireball.net/projects/markdown/syntax) syntax)" -h http://www.google.com/ -n ShoppingCartExample.Controllers`

##Licence

(The MIT License)

Copyright (c) 2013 Oded Welgreen ApiaryBlueprintGenerator@outlook.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.