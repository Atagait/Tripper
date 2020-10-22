# EZ Tripcode Generation
Depends on
- [System.Text.Encoding.CodePages](https://www.nuget.org/packages/System.Text.Encoding.CodePages/) for Shift-JIS encoding
- [CryptSharpStandard](https://www.nuget.org/packages/CryptSharpStandard) for crypt() implementation

For the most part ports [tripcode](https://github.com/aquilax/tripcode) from golang

```
var Tripping = new Tripping();
string Tripcode = Tripping.Tripcode("YourPassword");
```