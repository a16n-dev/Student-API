# Student-API

Created for the Database/API component of MSA Phase 1

## Deployed App
The API is running on an Azure app service and it can be accessed here: https://msa-sims-student.azurewebsites.net/index.html

## API Endpoints
### Student Endpoints
The student endpoints include all basic CRUD operations as well as an endpoint to retreive all students.
![Student endpoints](images/endpoints_student.png)
*Screenshot of student endpoints*

### Address Endpoints
The address endpoints include all basic CRUD operations as well as an endpoint to retreive all addresses. There is also an additional endpoint which allows an address to be fetched via the ID of the associated student
![Student endpoints](images/endpoints_address.png)
*Screenshot of address endpoints*

## SQL Database
The SQL Database has two tables, one for students and one for addresses. Below are screenshows showing example data in each of these tables:
