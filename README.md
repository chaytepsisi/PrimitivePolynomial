A form application to generate and check primitive polynomials in GF(2^q) .

Up to 40th degree ie checking and generating primitive polynomial over Gf(2^40), the application is feasible. For q=64, one may use the fact that multiplication of primitive polynomials is also primitive. 
This way, in order to generate a 64th degree primitive polynomial, we generate two 32nd degree primitive polynomials and multiply them. However, I do not know if this brings a weakness in cryptographic applications
and try to implement the following improvement for q=64 by [1]:


1) Factor 2^64 -1 which is r = 3×5×17×257×641×65537×6700417 (7 distinct prime factors,  factorized using by Wolfram Alpha)
2) Generate a new nth degree monic polynomial f(x)
3) Check for absence of linear factors: in this case x + 1 ie if 1 is a root of f.
4) Check if f(x) has two or more irreducible factors using the Berlekamp polynomial factorization method  <-- This is the most time consuming line
5) Since p=2, this step is trivial (x^(2^64 -1)=1 by definition, therefoer we get a 1=1)
6) Since n=64 and a=1, again we get a 1=1 and proceed
7) for m in{r/3, r/5,r/17, ...} check x^m != integer modulo f(x)


[1]: http://www.seanerikoconnor.freeservers.com/Mathematics/AbstractAlgebra/PrimitivePolynomials/theory.html
