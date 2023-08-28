**Address Book Management System API**

Welcome to the Address Book Management System API! This project provides a powerful and user-friendly API for managing user profiles and their contact details. This document outlines the various endpoints, input parameters, responses, and business rules that govern the functionality of this system.

**Authentication**

To access the API endpoints, you need to authenticate using the `/api/auth/signin` endpoint. Provide your `userName` (username or email address) and `password` in the request body to obtain an access token. Include the access token in the `Authorization` header as a Bearer token for subsequent requests.

**Metadata API**

Retrieve metadata lists such as Address Type, Email Address Type, Phone Number Type, and Country using the `/api/meta-data/ref-set/{key}` endpoint. Specify the `key` parameter in the path to get associated values for the metadata type.

**Create Address Book API**

Create a new address book entry using the `/api/account` endpoint. Provide the user's `firstName` and `lastName`, along with their communication details such as `emails`, `phones`, and `addresses`. Ensure you follow the provided structure for each communication detail.

**Get All Address Book API**

Retrieve a list of all address book entries using the `/api/account` endpoint. Use query parameters to control the number of results per page, sort order, and more.

**Get Count Address Book API**

Obtain the total count of address book entries stored in the database using the `/api/account/count` endpoint.

**Get Address Book API**

Retrieve details of a specific address book entry using the `/api/account/{id}` endpoint. Replace `{id}` with the unique UUID of the address book entry.

**Update Address Book API**

Update existing address book details using the `/api/account/{id}` endpoint. Provide the updated details in the request body, following the specified format.

**Delete Address Book API**

Delete a specific address book entry using the `/api/account/{id}` endpoint. Replace `{id}` with the UUID of the entry you wish to delete.

**File Upload API**

Upload image or file data using the `/api/asset/uploadFile` endpoint. Include the binary data of the file in the request body. The API will return an `id` that can be used to map the uploaded file to an account.

**Download API**

Retrieve a file object using the `/api/asset/downloadFile/{id}` endpoint. Replace `{id}` with the UUID of the file stored in the database.

**Business Rules**

- A profile must include a `firstName` and `lastName`.
- At least one address, email address, and phone number are required.
- Multiple addresses, email addresses, and phone numbers can be added.
- Address, email address, and phone number types are unique for each profile.
- The system operates as a single-page web application with responsive design.

Please refer to the provided endpoints, input parameters, and response formats when interacting with this API. Enjoy the seamless management of user profiles and communication details in your Address Book Management System!
