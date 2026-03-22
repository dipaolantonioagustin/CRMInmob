CREATE TABLE Contacts (
    Id INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(140) NOT NULL,
    Phone NVARCHAR(50) NULL,
    Email NVARCHAR(140) NULL,
    Notes NVARCHAR(MAX) NULL
);

CREATE TABLE PropertyFolders (
    Id INT IDENTITY PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL UNIQUE,
    Address NVARCHAR(300) NOT NULL,
    OperationType NVARCHAR(30) NOT NULL,
    CurrentStatus NVARCHAR(30) NOT NULL
);

CREATE TABLE CrmTasks (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(180) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    Priority INT NOT NULL,
    Status INT NOT NULL,
    DueDate DATETIME2 NOT NULL,
    ContactId INT NULL,
    PropertyFolderId INT NULL,
    AssignedToUserId NVARCHAR(450) NOT NULL,
    CreatedByUserId NVARCHAR(450) NOT NULL,
    CONSTRAINT FK_CrmTasks_Contacts FOREIGN KEY (ContactId) REFERENCES Contacts(Id),
    CONSTRAINT FK_CrmTasks_PropertyFolders FOREIGN KEY (PropertyFolderId) REFERENCES PropertyFolders(Id)
);

CREATE INDEX IX_CrmTasks_AssignedToUserId_Status_Priority
ON CrmTasks (AssignedToUserId, Status, Priority DESC, DueDate ASC);
