# Movie Reservation System <sub><sup>practice project</sup></sub>

Create a system for adding film screening times and reservations.
Just use CLI. For simplicity sake, let's ignore deletion, schedule conflicts of screening, etc.  

Upon loading of the program, the user will be prompted to choose between 3 screens.
### 1. FilmManagementScreen
- Add a **`Film`**
    |Properties|Description|
    |-|-|
    |id|unique identifier 4 Alphanumeric characters<br>e.g. `"45AL"`|
    |title|3-100 characters<br>e.g. `"Morbius: The Awakening"`|
    |duration|of the movie, must be between `1h30m` and `3h30m`|
    |minimumAge|age rating. if it's R18 (or `18`),<br> customers below the age of 18 cannot make a reservation|
- Search film/s by Title AND <br>show their status if they are `Showing` or not

### 2. ScreeningManagementScreen
- Add a **`Screening`**
    |Properties|Description|
    |-|-|
    |film|The **`Film`** to be shown|
    |cinemaCode|2-letter alphanumeric code for<br> where (which cinema) is it showing<br>e.g. Cinema1 = `"C1"`|
    |startTime|what time will it start in 24H format<br>e.g. `1345` for 01:45 PM<br><sub><sup>Ignore **schedule conflicts** if it's too hard to manage</sup></sub>|
    |endTime|what time it will end in 24H format<br>must be **derived** from film `duration` and `startTime`|
    |price|cost|
    |id|unique Screening Identifier code<br>comprises of `cinemaCode`, `Film.id` and `showingTime`<br>e.g. `"C1-45AL-1345"`|
- Search screening/s AND show their details such as which cinema and what time they start&end
    - search by Film Title (not exact match)<br>if you search for `"Morbius"`, you can get `"Morbius"` and `"Morbius II"`
    - search by Film ID (exact match)
    - search by Showing Time, get the screenings after the input time.<br>if you search for 1:00PM or `1300`, you get to see the screening on or after 1:00PM

### 3. ReservationManagementScreen
- create a **`Reservation`**

    |Properties|Description|
    |-|-|
    |Screening|-|
    |Customer|-|
    |id|consist of `Screening id` and Customers `FullName` all caps no space in between the first and last|

    ### **`Customer`**
    |Properties|Description|
    |-|-|
    |firstName|3-100 Alpha-only characters|
    |lastName|3-100 Alpha-only characters|
    |dateOfBirth||
    |Age|must be **derived** from `dateOfBirth`|
    
- search reservation
    - by Name (not exact match)
    - by Reservation ID


### Concepts Applied
- Object Oriented Programming
- Model View Presenter <sub><sup>Optional</sup></sub>
- Repository Pattern <sub><sup>Optional</sup></sub>
- Dependency Injection <sub><sup>Optional</sup></sub>
- Unit Testing
- Subject Under Test <sub><sup>Optional</sup></sub>