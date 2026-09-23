## Why is a single 20-parameter constructor a problem?

- A constructor with 20 parameters becomes difficult to read and change

- Required and optional values shares one place

- Every caller must understand the same parameter list to avoid value swapping for the same type
If you accidentally swap two strings, the code can still compile and run, but the invoice contains incorrect data

- There will be a maintenance problem if we add one more property
  we may need to add another constructor parameter, update every constructor call
  and update other code that creates objects of our class

- If the new property is optional, the constructor can become even more complicated with default parameters or different overloads

## Is this purely a "constructor is too long" problem?

- The answer is no, there is a deeper design problem

- if we looked at the properties, we can find different roles and responsibilities,
  Customer and order / payment info are unrelated,
  billing and shipping addresses refer to the same concept where it is better to use
  abstraction in this case

- so the first question we need to ask is why the object needs 20 or more unrelated data
  in the same place?

- Thats where we introduce the builder design pattern

## Why is this composed version better than the single big builder?

1. Single Responsibility

- Each builder has one clear responsibility
- AddressBuilder is responsible only for building and validating an address
- OrderBuilder is responsible only for building and validating order and payment information
- InvoiceBuilder is responsible for combining the customer information, addresses, and order information into the final Invoice
- so now each builder has one reason to change

2. Independent Validation

- AddressBuilder can guarantee that street, city, state, zip code, and country are provided before creating an Address
- Now InvoiceBuilder doesn't need to care about address rules, same applies to order

3. Reusing

- The same AddressBuilder can be reused for both billing and shipping addresses
- Without AddressBuilder, the single builder would need separate methods and validation logic for billing and shipping
- Therefore, it will the same address building concept twice

4. Readability at the Call Site

- we went from a single builder containing every property, which made it difficult to understand and read to this structure:
Build Billing Address
Build Shipping Address
Build Order Information
Build Invoice

- This makes the code easier to understand, easier to validate, easier to reuse, and easier to maintain as the system grows

