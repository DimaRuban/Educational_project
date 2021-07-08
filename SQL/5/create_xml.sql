DECLARE @InputFile XML = 
'<Products>
	<Product>
		<ProductID>ProductID_1</ProductID>
		<Name>Name1</Name>
		<Price>100</Price>
	</Product>
	<Product>
		<ProductID>ProductID_2</ProductID>
		<Name>Name2</Name>
		<Price>100</Price>
	</Product>
</Products>'

 EXEC InsertDataXML @InputFile; 
 ------------------------------
 Select * from Products;