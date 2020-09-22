CREATE VIEW [dbo].ViewDoctor AS
	SELECT FirstName, FastName, Patronymic, Specialty
	FROM dbo.Doctor AS doct
		INNER JOIN dbo.Specialty AS spec ON doct.Specialty_id = spec.id