CREATE TABLE Employees 
(
	Id, 
	FirstName, 
	LastName, 
	Title, 
	Notes
)

CREATE TABLE Customers
(
	AccountNumber, 
	FirstName, 
	LastName, 
	PhoneNumber, 
	EmergencyName, 
	EmergencyNumber, 
	Notes
)

CREATE TABLE RoomStatus 
(
	RoomStatus, 
	Notes
)

CREATE TABLE BedTypes
(
	BedType, 
	Notes
)

CREATE TABLE Rooms 
(
	RoomNumber, 
	RoomType, 
	BedType, 
	Rate, 
	RoomStatus, 
	Notes
)

CREATE TABLE Payments 
(
	Id, 
	EmployeeId, 
	PaymentDate, 
	AccountNumber, 
	FirstDateOccupied, 
	LastDateOccupied, 
	TotalDays, 
	AmountCharged, 
	TaxRate, 
	TaxAmount, 
	PaymentTotal, 
	Notes
)