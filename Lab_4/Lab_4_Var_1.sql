USE [ReceptionClinicDB]

CREATE VIEW [dbo].ViewSpecialty
	AS SELECT id, Specialty
	FROM [dbo].Specialty

CREATE VIEW [dbo].ViewDoctor
	AS SELECT id, FirstName, FastName, Patronymic, DateOfBirthday, Admission—ost, FixedPercentage, Specialty_id
	FROM [dbo].Doctor

CREATE VIEW [dbo].ViewReceipt
	AS SELECT Patient_id, Doctor_id, DateOfReceipt
	FROM [dbo].Receipt

CREATE VIEW [dbo].ViewPatient
	AS SELECT id, FirstName, FastName, Patronymic, DateOfBirthday
	FROM [dbo].Patient