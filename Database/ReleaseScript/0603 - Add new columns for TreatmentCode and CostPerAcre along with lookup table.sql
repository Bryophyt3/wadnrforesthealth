--create lookup for TreatmentCode(Name, DisplayName)
CREATE TABLE TreatmentCode(
TreatmentCodeID INT NOT NULL CONSTRAINT PK_TreatmentCode_TreatmentCodeID PRIMARY KEY,
TreatmentCodeName VARCHAR(100) NOT NULL,
TreatmentCodeDisplayName VARCHAR(100) NOT NULL,
)
GO
ALTER TABLE dbo.TreatmentCode
ADD CONSTRAINT AK_TreatmentCode_TreatmentCodeName UNIQUE(TreatmentCodeName)

ALTER TABLE dbo.TreatmentCode
ADD CONSTRAINT AK_TreatmentCode_TreatmentCodeDisplayName UNIQUE(TreatmentCodeDisplayName)

INSERT dbo.TreatmentCode (TreatmentCodeID, TreatmentCodeName, TreatmentCodeDisplayName) 
VALUES 
(1, 'BR-1', 'BR-1: Brush Control'),
(2, 'BR-2', 'BR-2: Brush Control'),
(3, 'PL-1-New', 'PL-1: New Plan 20-100 acres'),
(4, 'PL-1-Revised', 'PL-1: Revised Plan 20-100 acres'),
(5, 'PL-2-New', 'PL-2: New Plan 101-250 acres'),
(6, 'PL-2-Revised', 'PL-2: Revised Plan 101-250 acres'),
(7, 'PL-3-New', 'PL-3: New Plan 251-500 acres'),
(8, 'PL-3-Revised', 'PL-3: Revised Plan 251-500 acres'),
(9, 'PL-4-New', 'PL-4: New Plan 501-1000 acres'),
(10, 'PL-4-Revised', 'PL-4: Revised Plan 501-1000 acres'),
(11, 'PL-5-New', 'PL-5: New Plan 1001+ acres'),
(12, 'PL-5-Revised', 'PL-5: Revised Plan 1001+ acres'),
(13, 'PR-1', 'PR-1: Pruning'),
(14, 'PR-2', 'PR-2: Pruning'),
(15, 'RX-1', 'RX-1: Prescribed Broadcast Burning'),
(16, 'SL-1', 'SL-1: Slash Disposal'),
(17, 'SL-2', 'SL-2: Slash Disposal'),
(18, 'SL-3', 'SL-3: Slash Disposal'),
(19, 'SL-4', 'SL-4: Slash Disposal'),
(20, 'TH-1', 'TH-1: Thinning'),
(21, 'TH-2', 'TH-2: Thinning'),
(22, 'TH-3', 'TH-3: Thinning'),
(23, 'TH-4', 'TH-4: Thinning')

--add column to Treatement FK to TreatmentCode along with CostPerAcre
ALTER TABLE dbo.Treatment
ADD TreatmentCodeID INT NULL CONSTRAINT
FK_Treatment_TreatmentCode_TreatmentCodeID FOREIGN KEY (TreatmentCodeID) REFERENCES dbo.TreatmentCode(TreatmentCodeID);
GO

ALTER TABLE dbo.Treatment
ADD CostPerAcre MONEY NULL
GO

--add column to TreatementUpdate FK to TreatmentCode along with CostPerAcre
ALTER TABLE dbo.TreatmentUpdate
ADD TreatmentCodeID INT NULL CONSTRAINT
FK_TreatmentUpdate_TreatmentCode_TreatmentCodeID FOREIGN KEY (TreatmentCodeID) REFERENCES dbo.TreatmentCode(TreatmentCodeID);
GO

ALTER TABLE dbo.TreatmentUpdate
ADD CostPerAcre MONEY NULL
GO