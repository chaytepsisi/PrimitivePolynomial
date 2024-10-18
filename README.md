A form application to generate and check primitive polynomials in GF(2^q) .

Up to 40th degree ie checking and generating primitive polynomial over Gf(2^40), the application is feasible. For q=64, one may use the fact that multiplication of primitive polynomials is also primitive. 
This way, in order to generate a 64th degree primitive polynomial, we generate two 32nd degree primitive polynomials and multiply them. However, I do not know if this brings a weakness in cryptographic applications
and try to implement the following improvement for q=64 by [1]:


1) Factor 2^64 -1 which is 3×5×17×257×641×65537×6700417 (7 distinct prime factors)

[1]: http://www.seanerikoconnor.freeservers.com/Mathematics/AbstractAlgebra/PrimitivePolynomials/theory.html
