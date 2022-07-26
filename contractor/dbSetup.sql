CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS companies(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        name varchar(255) COMMENT 'Company Name',
        availableJobs INT COMMENT 'Number of Available Jobs'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS contractors(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        name varchar(255) NOT NULL COMMENT 'Contractor Name',
        profession varchar(255) NOT NULL COMMENT 'Contractor Profession'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS jobs(
        id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
        name varchar(255) NOT NULL COMMENT 'Job Name',
        companyId INT NOT NULL COMMENT 'Company Id',
        contractorId INT NOT NULL COMMENT 'Contractor Id',
        FOREIGN KEY (companyId) REFERENCES companies(id) ON DELETE CASCADE,
        FOREIGN KEY (contractorId) REFERENCES contractors(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';