# SimilarDoctors
Similar Doctors is a class that, provided a doctor will return a list of similar doctors in prioritized order.

### Definitions and Assumptions
The Doctor class has the following properties:
1. ID
2. Name
3. Specialty
4. Address
5. Latitude
6. Longitude
7. Review Score

#### Priority
Given these properties I decided that, when looking for a doctor, it is most important to ensure you're getting the right type of doctor. After that what would concern me most is the particular doctor's location and then how well they happen to be reviewed.

#### Further Assumptions
   Other assumptions I've made for this project:
1. A given address would be previously converted into a latitude and longitude in order to prevent having to continually calculate the coordinates for an address.
2. The list of doctors is gotten 
3. The list of doctors would be supplied to the functionality that would be returning the ordered list of doctors.
4.  The doctor to find similarities to would be supplied to the functionality returning the ordered list of doctors.

#### Things I'd Improve
- Create an IItem interface which would be implemented by the Doctor class.
- The SimilarDoctors class would make use of interfaces to reduce coupling and make it more capable for general use.
- SimilarDoctors would become SimilarItems or some such.
- Much more error and bounds checking in the doctor class' and associated tests, edge cases, nulls etc...
- Consider also ordering on a network property for the Doctor class.


#### Libraries used
- System
- System.Device.Location
- System.Collections.Generic
- Microsoft.VisualStudio.TestTools.UnitTesting
