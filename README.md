#Apiary Blueprint Generator

Generate an Apiary blueprint from a .Net XML documentation file. Integrate into your deployment process and use Apiary's future API to upload the blueprint for a full solution.
Every class is considered to be a section, and every method is considered to be a resource.

##Usage

The blueprint generator is a command line application. It accepts the following parameters:
<dl>
  <dt>Input file name (Required)</dt>
  <dd>The name of the input XML file</dd>
  <dt>Output file name (Required)</dt>
  <dd>The name of the output txt file</dd>
  <dt>API documentation title (Required)</dt>
  <dd>The Title for the API documentation</dd>
  <dt>Host address (Optional)</dt>
  <dd>The host address for the real server</dd>
  <dt>API documentation description (Optional)</dt>
  <dd>The description for the API</dd>
  <dt>Desired clasess namespace prefix (Optional)</dt>
  <dd>The desired controllers namespace (all other documentation will be filtered out)</dd>
</dl>


Example usage:
```..\..\..\ShoppingCartExample\bin\ShoppingCartExample.XML ShoppingCartExample.txt "Sample API v2" -d "Welcome to the our sample API documentation." -h http://www.google.com/ -n ShoppingCartExample.Controllers```

##Documentation Tags
<table>
  <tr>
    <th>Type</th><th>Tag</th><th>Description</th><th>Required</th>
  </tr>
  <tr>
    <td>Class</td>
	<td>&lt;title&gt;</td>
	<td>The section's title</td>
	<td>✓</td>
  </tr>
  <tr>
    <td>Class</td>
	<td>&lt;summary&gt;</td>
	<td>The section's description</td>
	<td>✓</td>
  </tr>
</table>



##Licence

(The MIT License)

Copyright (c) 2013 Oded Welgreen ApiaryBlueprintGenerator@outlook.com

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.