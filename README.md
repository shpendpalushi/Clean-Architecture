# hahn-data
The project consists in 2 main parts divided:
- Front-end = Built with Aurelia
- Backend build with ASP.Net 5 Web API
# Backend
 - After you clone the repository, perform dotnet restore in order to get the necessaey packages
 - In order to host it in docker run the docker build command with your prefered arguments.
 - Be careful to change where needed the paths.
 - Unit testing for date validations in .Net is built with XUnit. You can choose to run tests.
 - Default data for swagger integration is provided.
 - General Exception Handler is included as Middleware

#Front-end
- Built with Aurelia UI
- After you clone the repository perform the npm install in order to get the needed libraries.
- In order to run the project type au run --open to compile and run the aurelia app .
- To communicate with api inside /src/aurelia-json-schema-form/api/api.ts you can change the hosting uri of your backend.

Aurielia was fun :)
