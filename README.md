# LWareTest

Once the complete code is downloaded then the project should launch both Api and Client on the same port (First Load may take some time!) but please refer the instructions below in case of any issues:


Api Server 

Possible hurdles:

dotnet run : Run to bring up the api after the project has built successfully, or just run the project

run
dotnet dev-certs https --trust :  to add a dummy trust ceritifcate in order to bypass the ssl issues


Client Front End 

Possible hurdle:
If you IDE is not clever to run the npm install by default when the project is launched then please run 'npm install' on the ClientApp directory
For any timeout issue while launching the Angular App please restart the app or refesh the page.


C# Unit tests

There is a separate project to run the C# UNIT tests
