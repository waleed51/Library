Backend: 
* Clean Architechure and Separation of Concerns .
* prefere using MediatR & CQRS patterns and ignore Repository and UOW patterns.
* Cashing using IMemoryCash.
* Dapper as ORM.
* validation and protection.
* Create computed columns and for the JSON attributes which frequently search against and  Materialized View to enhance the performance of searching and query the complex data.
* To protect against SQL Injection, used parameterized queries.
* the wasn't enough to add test project to perform tests.

-- To can query the complex data stored in Book table specially for long base64 string in json string object "CoverBase64", I divide the "Book" table into two views (Materialized View), one for book details and another for book cover
and and create indexs to the new columns to try to decrease the query time, there is another alternative scenario to perform that which by using "Stored Procedure" as it save the excution plan for the queries.

Frontend:
* Separation of concerns: Keep the service and the component logic separate.
* generic service: To enable reusablity
* Intercesptor
* Reactive forms: Use FormControl and RxJS operators to handle user input and API calls reactively.
* Debounce: Use debounceTime to limit the number of API calls made while the user is typing.
* Cancellation: Use switchMap to cancel in-flight API requests if a new search is initiated.
* Error handling: Implement error handling for the API requests.
* Accessibility: Make search UI simple and accessible.
