-- =============================================================================
-- PAWS AND CLAWS RESCUE - DATABASE SCRIPT
-- =============================================================================

-- 50143956 - Christoph van Jaarsveld
-- 46251960 - Luan du Plessis
-- 49019767 - Pieta Hattingh
-- 45926808 - Sune Muller
-- 46036482 - Zoe du Plessis


-- =============================================================================
-- DROP EXISTING TABLES (clean start)
-- =============================================================================
BEGIN
    FOR t IN (
        SELECT table_name FROM user_tables
        WHERE table_name IN (
            'DONATION','TREATMENT_RECORD','TREATMENT_PROVISION',
            'ADOPTION','VETERINARIAN','VETERINARY_ASSISTANT',
            'ADOPTION_COORDINATOR','ANIMAL','ADOPTER','STAFF',
            'TREATMENT','MEDICAL_PROVISION','KENNEL','DONOR','STAFF_ROLE'
        )
    ) LOOP
        EXECUTE IMMEDIATE 'DROP TABLE ' || t.table_name || ' CASCADE CONSTRAINTS';
    END LOOP;
END;
/

-- =============================================================================
-- DROP EXISTING SEQUENCES (clean start)
-- =============================================================================
BEGIN
    FOR s IN (
        SELECT sequence_name FROM user_sequences
        WHERE sequence_name IN (
            'ANIMAL_SEQ','KENNEL_ID_SEQ','DONOR_ID_SEQ','ADOPTER_ID_SEQ',
            'ADOPTION_ID_SEQ','STAFF_ID_SEQ','STAFF_ROLE_ID_SEQ',
            'TREATMENTID_SEQ','MEDICALPROV_ID_SEQ','TREATMENTRECORD_SEQ',
            'DONATION_ID_SEQ'
        )
    ) LOOP
        EXECUTE IMMEDIATE 'DROP SEQUENCE ' || s.sequence_name;
    END LOOP;
END;
/

-- =============================================================================
-- CREATE SEQUENCES
-- =============================================================================

-- CREATE SEQUENCE for KENNEL table
CREATE SEQUENCE kennel_ID_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 10000
NOCYCLE;

-- CREATE SEQUENCE for DONOR table
CREATE SEQUENCE donor_ID_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 1000000
NoCYCLE;

-- CREATE SEQUENCE for staff roles
CREATE SEQUENCE staff_role_id_seq   
START WITH 1   
INCREMENT BY 1 
MINVALUE 1   
MAXVALUE 100
NOCYCLE;

-- CREATE SEQUENCE for STAFF
CREATE SEQUENCE staff_ID_seq        
START WITH 1 
INCREMENT BY 1 
MINVALUE 1   
MAXVALUE 100000 
NOCYCLE;

-- CREATE SEQUENCE for ANIMAL table
CREATE SEQUENCE animal_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE;


-- Create SEQUENCE for ADOPTER table
CREATE SEQUENCE Adopter_ID_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE;


-- Create SEQUENCE for ADOPTION table
CREATE SEQUENCE Adoption_ID_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE;


-- CREATE SEQUENCE for TREATMENT Table
CREATE SEQUENCE treatmentID_seq
start with 1
increment by 1
minvalue 1
maxvalue 100000
NOCYCLE;


-- CREATE SEQUENCE for MEDICAL_PROVISION table
CREATE SEQUENCE medicalProv_ID_seq
start with 1
increment by 1
minvalue 1
maxvalue 100000
NOCYCLE;

-- CREATE SEQUENCE for TREATMENT_RECORD table
CREATE SEQUENCE treatmentrecord_seq
START WITH 1
INCREMENT BY 1
MINVALUE 1
MAXVALUE 100000
NOCYCLE;


CREATE SEQUENCE donation_ID_seq     
START WITH 1   
INCREMENT BY 1 
MINVALUE 1   
MAXVALUE 100000 
NOCYCLE;

-- =============================================================================
-- CREATE TABLES
-- =============================================================================

-- KENNEL: Stores kennel/enclosure details
-- ------------------------------------------------------------
CREATE TABLE KENNEL (
    kennel_ID NUMBER,
    sizes VARCHAR2(20) NOT NULL,
    availability_status VARCHAR2(20) NOT NULL,
	CONSTRAINT pk_kennel PRIMARY KEY (kennel_ID),
    CONSTRAINT chk_kennel_size 
		CHECK (sizes IN ('Small', 'Medium', 'Large')),
    CONSTRAINT chk_kennel_status 
		CHECK (availability_status IN ('Available', 'Occupied', 'Maintenance'))
);


-- DONOR: People who make financial donations
-- ------------------------------------------------------------
CREATE TABLE DONOR (
    donor_ID NUMBER,
    name VARCHAR2(50) NOT NULL,
    surname VARCHAR2(50) NOT NULL,
    email VARCHAR2(100) UNIQUE,
    phone_number VARCHAR2(10),
	CONSTRAINT pk_donor PRIMARY KEY (donor_ID)
);


-- STAFF_ROLE: Role definitions for staff members
-- ------------------------------------------------------------
CREATE TABLE STAFF_ROLE (
    role_ID NUMBER CONSTRAINT staffrole_id_pk PRIMARY KEY,
    role_name VARCHAR2(50) NOT NULL,
    job_description VARCHAR2(255)
);


-- STAFF: All staff members (parent entity for sub-entities)
-- ------------------------------------------------------------
CREATE TABLE STAFF (
    staff_ID NUMBER(4) CONSTRAINT staff_id_pk PRIMARY KEY,
    role_ID  NUMBER NOT NULL,
    first_name VARCHAR2(50) NOT NULL,
    last_name VARCHAR2(50) NOT NULL,
    email_address VARCHAR2(100) UNIQUE NOT NULL,
    phone_number VARCHAR2(10),
    date_hired DATE NOT NULL,
    years_worked NUMBER(2) CHECK (years_worked >= 0),
    CONSTRAINT fk_staff_role FOREIGN KEY (role_ID) REFERENCES STAFF_ROLE(role_ID)
);


-- VETERINARY_ASSISTANT: Sub-entity of STAFF
-- ------------------------------------------------------------
CREATE TABLE VETERINARY_ASSISTANT (
    staff_ID NUMBER(4) CONSTRAINT vetassist_id_pk PRIMARY KEY,
    training_status VARCHAR2(30) NOT NULL,
    CONSTRAINT chk_training_status CHECK (training_status IN ('Completed', 'In Progress', 'Not Started')),
    CONSTRAINT fk_vetassist_staff FOREIGN KEY (staff_ID) REFERENCES STAFF(staff_ID)
);


-- VETERINARIAN: Sub-entity of STAFF
-- ------------------------------------------------------------
CREATE TABLE VETERINARIAN (
    staff_ID NUMBER(4) CONSTRAINT veterinarian_staff_pk PRIMARY KEY,
    vetAssistant_ID NUMBER(4),
    license_number VARCHAR2(20) UNIQUE NOT NULL,
    specialization VARCHAR2(50) NOT NULL,
    total_animals_treated NUMBER(3) DEFAULT 0 CHECK (total_animals_treated >= 0) NOT NULL,
    CONSTRAINT fk_vet_staff FOREIGN KEY (staff_ID) REFERENCES STAFF(staff_ID),
    CONSTRAINT fk_vet_assistant FOREIGN KEY (vetAssistant_ID) REFERENCES VETERINARY_ASSISTANT(staff_ID)
);


-- ADOPTION_COORDINATOR: Sub-entity of STAFF
-- ------------------------------------------------------------
CREATE TABLE ADOPTION_COORDINATOR (
    staff_ID NUMBER(4),
    total_adoptions_processed NUMBER(4) DEFAULT 0 CHECK (total_adoptions_processed >= 0) NOT NULL,
	CONSTRAINT Coordinator_PK PRIMARY KEY (staff_ID),
    CONSTRAINT fk_adoptcoord_staff FOREIGN KEY (staff_ID) REFERENCES STAFF(staff_ID)
);


-- MEDICAL_PROVISION: Medical supplies/stock
-- ------------------------------------------------------------
CREATE TABLE MEDICAL_PROVISION (
    medicalProv_ID NUMBER CONSTRAINT pk_medical_provision PRIMARY KEY,
    description VARCHAR2(225),
    inStock NUMBER CHECK (inStock >= 0),
    cost NUMBER(10,2) CHECK (cost >= 0)
);


-- TREATMENT: Types of treatments that can be performed
-- ------------------------------------------------------------
CREATE TABLE TREATMENT (
    treatment_ID NUMBER CONSTRAINT pk_treatment PRIMARY KEY,
    name VARCHAR2(50) NOT NULL,
    description VARCHAR2(255),
    category VARCHAR2(50),
    medicalInstruction VARCHAR2(255)
);


-- TREATMENT_PROVISION: Links treatments to medical provisions used
-- ------------------------------------------------------------
CREATE TABLE TREATMENT_PROVISION (
    treatment_ID NUMBER,
    medicalProv_ID NUMBER,
    quantity_used NUMBER CHECK (quantity_used > 0),
    CONSTRAINT pk_treatment_provision 
		PRIMARY KEY(treatment_ID, medicalProv_ID),
    CONSTRAINT fk_tp_treatment 
		FOREIGN KEY(treatment_ID) REFERENCES TREATMENT(treatment_ID),
    CONSTRAINT fk_tp_medicalprov 
		FOREIGN KEY(medicalProv_ID) REFERENCES MEDICAL_PROVISION(medicalProv_ID)
);


-- ANIMAL: Animals currently or previously in the rescue
-- ------------------------------------------------------------
CREATE TABLE ANIMAL (
    animal_ID NUMBER(3) CONSTRAINT animal_id_pk PRIMARY KEY,
    kennel_ID NUMBER(3) NOT NULL,
    category VARCHAR2(30) NOT NULL,
    breed VARCHAR2(40) NOT NULL,
    age NUMBER(2) CHECK (age > 0) NOT NULL,
    condition VARCHAR2(50) NOT NULL,
    arrivalDate DATE NOT NULL,
    adoption_availability VARCHAR2(20) NOT NULL,
    CONSTRAINT adopt_avail CHECK (adoption_availability IN ('Available', 'Not Available')),
    CONSTRAINT fk_animal_kennel FOREIGN KEY (kennel_ID) REFERENCES KENNEL(kennel_ID)
);


-- TREATMENT_RECORD: Records of treatments performed on animals
-- ------------------------------------------------------------
CREATE TABLE TREATMENT_RECORD (
    record_ID NUMBER(3) CONSTRAINT treatmentrecord_id_pk PRIMARY KEY,
    animal_ID NUMBER(3) NOT NULL REFERENCES ANIMAL(animal_ID),
    treatment_ID NUMBER(4) NOT NULL REFERENCES TREATMENT(treatment_ID),
    staff_ID NUMBER(4) NOT NULL REFERENCES VETERINARIAN(staff_ID),
    treatment_date DATE NOT NULL,
    treatment_result VARCHAR2(100) NOT NULL
);


-- ADOPTER: People who adopt animals
-- ------------------------------------------------------------
CREATE TABLE ADOPTER (
    adopter_ID NUMBER(5) NOT NULL,
    first_name VARCHAR2(50) NOT NULL,
    last_name VARCHAR2(50) NOT NULL,
    phone_number VARCHAR2(15),
    email_address VARCHAR2(100) UNIQUE,
    city VARCHAR2(50),
    postal_code VARCHAR2(10),
    address VARCHAR2(150),
	CONSTRAINT Adopter_PK PRIMARY KEY (Adopter_ID)
);


-- ADOPTION: Records of completed adoptions
-- ------------------------------------------------------------
CREATE TABLE ADOPTION (
    adoption_ID NUMBER(5) NOT NULL,
    animal_ID NUMBER(3) NOT NULL,
    adopter_ID NUMBER(5) NOT NULL,
    staff_ID NUMBER(4) NOT NULL,
    adoption_date DATE NOT NULL,
    adoption_fee NUMBER(10,2) CHECK (adoption_fee >= 0) NOT NULL,
	
	CONSTRAINT Adoption_PK PRIMARY KEY (Adoption_ID),
    CONSTRAINT FK_Adopter FOREIGN KEY (Adopter_ID)
        REFERENCES ADOPTER(Adopter_ID),
    CONSTRAINT FK_Coordinator FOREIGN KEY (staff_ID)
        REFERENCES ADOPTION_COORDINATOR(staff_ID),
    CONSTRAINT FK_Adoption_animal FOREIGN KEY (animal_ID) 
		REFERENCES ANIMAL(animal_ID)
);


-- DONATION: Donations made by donors toward specific animals
-- ------------------------------------------------------------
CREATE TABLE DONATION (
    donation_ID NUMBER CONSTRAINT pk_donation PRIMARY KEY,
    donor_ID NUMBER NOT NULL,
    animal_ID NUMBER NOT NULL,
    donation_amount NUMBER(10,2) NOT NULL,
    donation_date DATE DEFAULT SYSDATE,
    CONSTRAINT fk_donation_donor FOREIGN KEY(donor_ID) 
		REFERENCES DONOR(donor_ID),
    CONSTRAINT fk_donation_animal FOREIGN KEY (animal_ID) 
		REFERENCES ANIMAL(animal_ID),
    CONSTRAINT chk_donation_amount 
		CHECK(donation_amount > 0)
);


-- =============================================================================
-- INDEXES
-- =============================================================================

CREATE INDEX idx_kennel_status   
ON KENNEL(availability_status);

CREATE INDEX idx_arrival_date    
ON ANIMAL(arrivalDate);

CREATE INDEX idx_animal_breed    
ON ANIMAL(breed);

CREATE INDEX idx_treatment_staff 
ON TREATMENT_RECORD(staff_ID);

-- =============================================================================
-- VIEWS
-- =============================================================================

-- Lists all animals currently available for adoption
CREATE OR REPLACE VIEW AVAILABLE_ANIMALS AS
SELECT animal_ID, category, breed, age, condition
FROM ANIMAL
WHERE adoption_availability = 'Available';


-- Shows each vet alongside their treatment records
CREATE OR REPLACE VIEW VET_TREATMENT_SUMMARY AS
SELECT v.staff_ID, v.specialization, t.record_ID, t.treatment_result
FROM VETERINARIAN v
JOIN TREATMENT_RECORD t ON v.staff_ID = t.staff_ID;


-- Full adoption view which includes adopter name, coordinator name, date and fee
CREATE OR REPLACE VIEW ALL_ADOPTIONS AS
SELECT
    a.adoption_ID,
    ad.first_name || ' ' || ad.last_name AS "Adopter Name",
    s.first_name  || ' ' || s.last_name AS "Coordinator Name",
    a.adoption_date,
    a.adoption_fee
FROM ADOPTION a
JOIN ADOPTER ad ON a.adopter_ID = ad.adopter_ID
JOIN ADOPTION_COORDINATOR ac ON a.staff_ID = ac.staff_ID
JOIN STAFF s ON ac.staff_ID = s.staff_ID;


-- Filter aproved adoptions
CREATE OR REPLACE VIEW Approved_Adoptions AS
SELECT *
FROM Adoption;


-- Summarises total adoptions per adopter
CREATE OR REPLACE VIEW ADOPTER_SUMMARY AS
SELECT
    ad.adopter_ID,
    ad.first_name,
    ad.last_name,
    COUNT(a.adoption_ID) AS "Total Adoptions"
FROM ADOPTER ad
LEFT JOIN ADOPTION a ON ad.adopter_ID = a.adopter_ID
GROUP BY ad.adopter_ID, ad.first_name, ad.last_name;


-- =============================================================================
-- INSERT TEST DATA (POPULATE DATABASE)
-- =============================================================================

-- KENNEL entries
-- ------------------------------------------------------------
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (101, 'Large', 'Occupied');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (102, 'Small', 'Occupied');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (103, 'Large', 'Occupied');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (104, 'Medium','Occupied');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (105, 'Small', 'Occupied');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (106, 'Medium', 'Available');
INSERT INTO KENNEL (kennel_ID, sizes, availability_status) VALUES (107, 'Small', 'Maintenance');


-- DONOR entries
-- ------------------------------------------------------------
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (1, 'Marlene', 'Botha',   'marlene.botha@gmail.com', '0821112233');
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (2, 'Johan', 'Meyer',   'johan.meyer@gmail.com', '0832223344');
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (3, 'Ayesha', 'Naidoo',  'ayesha.naidoo@gmail.com', '0843334455');
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (4, 'Pieter', 'Smit',    'pieter.smit@gmail.com', '0854445566');
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (5, 'Lerato', 'Mokoena', 'lerato.mokoena@gmail.com','0865556677');
INSERT INTO DONOR (donor_ID, name, surname, email, phone_number) VALUES (6, 'Henry', 'Jacobs',  'henry.jacobs@gmail.com', '0876667788');


-- STAFF_ROLE entries
-- ------------------------------------------------------------
INSERT INTO STAFF_ROLE (role_ID, role_name, job_description) VALUES (1, 'Veterinarian', 'Records medical examinations and performs treatments.');
INSERT INTO STAFF_ROLE (role_ID, role_name, job_description) VALUES (2, 'Veterinary Assistant', 'Assists veterinarians during treatments and daily animal care.');
INSERT INTO STAFF_ROLE (role_ID, role_name, job_description) VALUES (3, 'Adoption Coordinator', 'Processes adoption applications and completed adoptions.');


-- STAFF entries
-- ------------------------------------------------------------
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (201, 1, 'Elise', 'Pretorius', 'elise.pretorius@pawsrescue.org', '0711112222', TO_DATE('2021-02-15', 'YYYY-MM-DD'), 5);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (202, 1, 'Michael', 'Nkosi', 'michael.nkosi@pawsrescue.org', '0712223333', TO_DATE('2023-05-20', 'YYYY-MM-DD'), 3);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (203, 1, 'Janine',  'Coetzee', 'janine.coetzee@pawsrescue.org', '0713334444', TO_DATE('2024-01-10', 'YYYY-MM-DD'), 2);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (301, 2, 'Bianca',  'Fourie', 'bianca.fourie@pawsrescue.org', '0721112222', TO_DATE('2022-03-12', 'YYYY-MM-DD'), 4);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (302, 2, 'Thabo', 'Mokoena', 'thabo.mokoena@pawsrescue.org', '0722223333', TO_DATE('2023-07-18', 'YYYY-MM-DD'), 3);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (401, 3, 'Anika', 'Venter', 'anika.venter@pawsrescue.org', '0731112222', TO_DATE('2020-09-01', 'YYYY-MM-DD'), 6);
 
INSERT INTO STAFF (staff_ID, role_ID, first_name, last_name, email_address, phone_number, date_hired, years_worked)
VALUES (402, 3, 'Sipho',   'Dlamini', 'sipho.dlamini@pawsrescue.org', '0732223333', TO_DATE('2022-11-25', 'YYYY-MM-DD'), 4);


-- VETERINARY_ASSISTANT entries
-- ------------------------------------------------------------
INSERT INTO VETERINARY_ASSISTANT (staff_ID, training_status) VALUES (301, 'Completed');
INSERT INTO VETERINARY_ASSISTANT (staff_ID, training_status) VALUES (302, 'In Progress');


-- VETERINARIAN entries
-- ------------------------------------------------------------
INSERT INTO VETERINARIAN (staff_ID, vetAssistant_ID, license_number, specialization, total_animals_treated)
VALUES (201, 301, 'LIC1001', 'General Surgery', 15);

INSERT INTO VETERINARIAN (staff_ID, vetAssistant_ID, license_number, specialization, total_animals_treated)
VALUES (202, 302, 'LIC1002', 'Dermatology', 10);

INSERT INTO VETERINARIAN (staff_ID, vetAssistant_ID, license_number, specialization, total_animals_treated)
VALUES (203, 301, 'LIC1003', 'Spinal Surgery', 12);


-- ADOPTION_COORDINATOR entries
-- ------------------------------------------------------------
INSERT INTO ADOPTION_COORDINATOR (staff_ID, total_adoptions_processed) VALUES (401, 24);
INSERT INTO ADOPTION_COORDINATOR (staff_ID, total_adoptions_processed) VALUES (402, 18);


-- ANIMAL entries
-- ------------------------------------------------------------
INSERT INTO ANIMAL (animal_ID, kennel_ID, category, breed, age, condition, arrivalDate, adoption_availability)
VALUES (1, 101, 'Dog', 'Labrador', 3, 'Healthy', TO_DATE('2026-04-10', 'YYYY-MM-DD'), 'Available');
 
INSERT INTO ANIMAL (animal_ID, kennel_ID, category, breed, age, condition, arrivalDate, adoption_availability)
VALUES (2, 102, 'Cat', 'Siamese', 2, 'Minor Injury', TO_DATE('2026-04-18', 'YYYY-MM-DD'), 'Not Available');
 
INSERT INTO ANIMAL (animal_ID, kennel_ID, category, breed, age, condition, arrivalDate, adoption_availability)
VALUES (3, 103, 'Dog', 'German Shepherd', 5, 'Recovering', TO_DATE('2026-03-10', 'YYYY-MM-DD'), 'Available');
 
INSERT INTO ANIMAL (animal_ID, kennel_ID, category, breed, age, condition, arrivalDate, adoption_availability)
VALUES (4, 104, 'Cat', 'Tabby', 1, 'Healthy', TO_DATE('2026-04-25', 'YYYY-MM-DD'), 'Available');
 
INSERT INTO ANIMAL (animal_ID, kennel_ID, category, breed, age, condition, arrivalDate, adoption_availability)
VALUES (5, 105, 'Dog', 'Border Collie', 4, 'Critical', TO_DATE('2026-04-28', 'YYYY-MM-DD'), 'Not Available');


-- ADOPTER entries
-- ------------------------------------------------------------
INSERT INTO ADOPTER (adopter_ID, first_name, last_name, phone_number, email_address, city, postal_code, address)
VALUES (1, 'Carla', 'Jacobs', '0811111111', 'carla.jacobs@gmail.com', 'Springfield', '1449', '12 Rose Street');
 
INSERT INTO ADOPTER (adopter_ID, first_name, last_name, phone_number, email_address, city, postal_code, address)
VALUES (2, 'Neo',   'Mabena', '0822222222', 'neo.mabena@yahoo.com', 'Potchefstroom', '2531', '45 Oak Avenue');
 
INSERT INTO ADOPTER (adopter_ID, first_name, last_name, phone_number, email_address, city, postal_code, address)
VALUES (3, 'Sarah', 'Williams', '0833333333', 'sarah.williams@gmail.com', 'Springfield', '1450', '78 Lily Road');


-- ADOPTION entries
-- ------------------------------------------------------------
INSERT INTO ADOPTION (adoption_ID, animal_ID, adopter_ID, staff_ID, adoption_date, adoption_fee)
VALUES (1, 1, 1, 401, TO_DATE('2026-03-21', 'YYYY-MM-DD'), 850.00);
 
INSERT INTO ADOPTION (adoption_ID, animal_ID, adopter_ID, staff_ID, adoption_date, adoption_fee)
VALUES (2, 3, 2, 402, TO_DATE('2026-03-22', 'YYYY-MM-DD'), 550.00);
 
INSERT INTO ADOPTION (adoption_ID, animal_ID, adopter_ID, staff_ID, adoption_date, adoption_fee)
VALUES (3, 4, 3, 401, TO_DATE('2026-03-23', 'YYYY-MM-DD'), 1250.00);


-- MEDICAL_PROVISION entries
-- ------------------------------------------------------------
INSERT INTO MEDICAL_PROVISION (medicalProv_ID, description, inStock, cost) VALUES (1, 'Amoxicillin Tablets', 20, 5.50);
INSERT INTO MEDICAL_PROVISION (medicalProv_ID, description, inStock, cost) VALUES (2, 'Rabies Vaccine', 1, 85.00);
INSERT INTO MEDICAL_PROVISION (medicalProv_ID, description, inStock, cost) VALUES (3, 'Sterile Bandage Rolls', 4, 12.00);


-- TREATMENT entries
-- ------------------------------------------------------------
INSERT INTO TREATMENT (treatment_ID, name, description, category, medicalInstruction)
VALUES (401, 'Antibiotic Course', 'Full course of antibiotics for bacterial infection', 'Medicinal', 'Administer twice daily with food for 7 days');
 
INSERT INTO TREATMENT (treatment_ID, name, description, category, medicalInstruction)
VALUES (402, 'Rabies Vaccination', 'Standard annual rabies vaccination', 'Preventative', 'Single injection, repeat annually');
 
INSERT INTO TREATMENT (treatment_ID, name, description, category, medicalInstruction)
VALUES (403, 'Wound Dressing', 'Cleaning and dressing of open wounds', 'Surgical', 'Clean wound with saline, apply bandage, change every 48 hours');


-- TREATMENT_PROVISION entries
-- ------------------------------------------------------------
INSERT INTO TREATMENT_PROVISION (treatment_ID, medicalProv_ID, quantity_used) VALUES (401, 1, 14);
INSERT INTO TREATMENT_PROVISION (treatment_ID, medicalProv_ID, quantity_used) VALUES (402, 2,  1);
INSERT INTO TREATMENT_PROVISION (treatment_ID, medicalProv_ID, quantity_used) VALUES (403, 3,  3);


-- TREATMENT_RECORD entries
-- ------------------------------------------------------------
INSERT INTO TREATMENT_RECORD (record_ID, animal_ID, treatment_ID, staff_ID, treatment_date, treatment_result)
VALUES (1, 1, 402, 201, TO_DATE('2026-04-12', 'YYYY-MM-DD'), 'Vaccination Successful');
 
INSERT INTO TREATMENT_RECORD (record_ID, animal_ID, treatment_ID, staff_ID, treatment_date, treatment_result)
VALUES (4, 1, 401, 201, TO_DATE('2026-04-15', 'YYYY-MM-DD'), 'Follow-up Treatment');
 
INSERT INTO TREATMENT_RECORD (record_ID, animal_ID, treatment_ID, staff_ID, treatment_date, treatment_result)
VALUES (2, 2, 403, 202, TO_DATE('2026-04-20', 'YYYY-MM-DD'), 'Wound Treated');
 
INSERT INTO TREATMENT_RECORD (record_ID, animal_ID, treatment_ID, staff_ID, treatment_date, treatment_result)
VALUES (3, 3, 401, 203, TO_DATE('2026-03-12', 'YYYY-MM-DD'), 'Antibiotic Course Started');


-- DONATION entries (donation_ID added as surrogate PK)
-- ------------------------------------------------------------
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (1,  1, 1,  750.00, TO_DATE('2026-04-11', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (2,  2, 1,  350.00, TO_DATE('2026-04-13', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (3,  3, 2, 1200.00, TO_DATE('2026-04-19', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (4,  4, 2,  250.00, TO_DATE('2026-04-21', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (5,  5, 5,  900.00, TO_DATE('2026-04-29', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (6,  6, 5, 1100.00, TO_DATE('2026-04-30', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (7,  1, 2,  500.00, TO_DATE('2026-04-22', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (8,  2, 3,  450.00, TO_DATE('2026-03-15', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (9,  3, 1,  300.00, TO_DATE('2026-04-14', 'YYYY-MM-DD'));
INSERT INTO DONATION (donation_ID, donor_ID, animal_ID, donation_amount, donation_date) VALUES (10, 4, 3,  800.00, TO_DATE('2026-03-16', 'YYYY-MM-DD'));

COMMIT;


-- =============================================================================
-- SELECT QUERIES
-- =============================================================================

-- [Limit Columns & Rows] Animals available for adoption
SELECT animal_ID, category, breed, age
FROM ANIMAL
WHERE adoption_availability = 'Available';

-- [Sorting] Animals sorted from oldest to youngest
SELECT animal_ID, category, breed, age
FROM ANIMAL
ORDER BY age DESC;

-- [LIKE & AND] Vets specialising in Surgery who treated more than 10 animals
SELECT staff_ID, license_number, specialization, total_animals_treated
FROM VETERINARIAN
WHERE specialization LIKE '%Surgery%'
AND total_animals_treated > 10;

-- [OR] Animals in critical or recovering condition
SELECT animal_ID, category, breed, age, condition
FROM ANIMAL
WHERE condition = 'Critical'
OR condition = 'Recovering';

-- [Character Functions] Vet specializations in uppercase
SELECT staff_ID,
       UPPER(specialization) AS SPECIALIZATION
FROM VETERINARIAN;

-- [ROUND] Average donation amount rounded to 2 decimal places
SELECT ROUND(AVG(donation_amount), 2) AS "Average Donation"
FROM DONATION;

-- [TRUNC] Base cost of each medical provision 2.7
SELECT description, TRUNC(cost) AS "Base Cost"
FROM MEDICAL_PROVISION;

-- [Date Functions] Animals that arrived in the last 30 days 
SELECT animal_ID, arrivalDate
FROM ANIMAL
WHERE arrivalDate >= SYSDATE - 30;
 
-- [Date Functions] Years each staff member has been employed
SELECT first_name,
       EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM date_hired) AS "Years At Rescue"
FROM STAFF;

-- [Aggregate Functions] Total current animals in shelter
SELECT COUNT(animal_id) AS Total_Animals 
FROM ANIMAL;

-- [Aggregate Functions] Total and average donation per animal
SELECT animal_ID,
       COUNT(*) AS total_donations,
       SUM(donation_amount) AS total_donated,
       ROUND(AVG(donation_amount), 2) AS avg_donation
FROM DONATION
GROUP BY animal_ID;


-- [Group By] Count how many animals exists in group category (Cat, Dog)
SELECT category, COUNT(*) FROM ANIMAL GROUP BY category;

-- [Group By & Having] Animals that have received more than one treatment
SELECT animal_ID, COUNT(*) AS num_treatments
FROM TREATMENT_RECORD
GROUP BY animal_ID
HAVING COUNT(*) > 1;

-- [Inner Join] lists animals together with the sizes of the kennel they are assigned to
SELECT A.animal_id, K.sizes 
FROM ANIMAL A 
JOIN KENNEL K ON A.kennel_id = K.kennel_id;

-- [Join Multiple] Shows which adopter adopted which animal and displays the coordinator
SELECT ADO.first_name, AN.category, ST.first_name AS Coordinator 
FROM ADOPTION AD 
JOIN ADOPTER ADO ON AD.adopter_id = ADO.adopter_id 
JOIN ANIMAL AN ON AD.animal_id = AN.animal_id 
JOIN STAFF ST ON AD.staff_id = ST.staff_id;

-- [Sub-queries] Animals that have not received any treatments
SELECT animal_ID, category
FROM ANIMAL
WHERE animal_ID NOT IN (
	SELECT animal_ID FROM TREATMENT_RECORD
);

-- [Sub-queries] Adoptions with a fee above the average adoption fee
SELECT animal_ID, adoption_fee
FROM ADOPTION
WHERE adoption_fee > (
    SELECT AVG(adoption_fee) FROM ADOPTION
);

-- [OUTER Join] All kennels with their assigned animals
SELECT k.kennel_ID, k.sizes, k.availability_status,
       a.animal_ID, a.category, a.breed
FROM KENNEL k
LEFT OUTER JOIN ANIMAL a ON k.kennel_ID = a.kennel_ID
ORDER BY k.kennel_ID;

-- [Math & Logic] Projected stock after 10% usage
SELECT description,
       inStock,
       ROUND(inStock * 0.9, 0) AS projected_stock
FROM MEDICAL_PROVISION
ORDER BY description;

-- [TRUNC / Date] Days each animal has been in the shelter
SELECT animal_ID, category, breed,
       TRUNC(SYSDATE - arrivalDate) AS days_in_shelter
FROM ANIMAL;

-- [Joins] Full adoption details which include adopter, coordinator, animal, fee
SELECT a.adoption_ID,
       ad.first_name || ' ' || ad.last_name AS adopter_name,
       s.first_name  || ' ' || s.last_name AS coordinator_name,
       an.category || ' - ' || an.breed AS animal,
       a.adoption_date,
       a.adoption_fee
FROM ADOPTION a
JOIN ADOPTER ad ON a.adopter_ID = ad.adopter_ID
JOIN ADOPTION_COORDINATOR ac ON a.staff_ID  = ac.staff_ID
JOIN STAFF s ON ac.staff_ID  = s.staff_ID
JOIN ANIMAL an ON a.animal_ID  = an.animal_ID;


-- =============================================================================
-- EXTRA FUNCTIONALITY / WOW FACTOR QUERIES
-- =============================================================================

-- High-value donors who donated to critical animals above the average donation total
SELECT D.name, D.surname, SUM(DN.donation_amount) AS Total_Donated
FROM DONOR D
JOIN DONATION DN ON D.donor_id = DN.donor_id
WHERE DN.animal_id IN (SELECT animal_id FROM ANIMAL WHERE condition = 'Critical')
GROUP BY D.name, D.surname
HAVING SUM(DN.donation_amount) > (SELECT AVG(donation_amount) FROM DONATION);


-- Calculates the "Utilization Ratio" of medical provisions.
SELECT T.description AS Treatment, 
       MP.description AS Provision,
       TP.quantity_used,
       MP.inStock,
       ROUND((TP.quantity_used / NULLIF(MP.inStock, 0)) * 100, 2) || '%' AS Inventory_Impact_Percent
FROM TREATMENT T
JOIN TREATMENT_PROVISION TP ON T.treatment_id = TP.treatment_id
JOIN MEDICAL_PROVISION MP ON TP.medicalProv_ID = MP.medicalProv_ID
WHERE (TP.quantity_used / NULLIF(MP.inStock, 0)) > 0.5;


-- Full animal report which includes kennel, treatment, vet, adopter
SELECT
    a.animal_ID,
    a.breed,
    k.kennel_ID AS home_kennel,
    t.name AS treatment,
    s.last_name AS vet,
    ad.first_name || ' ' || ad.last_name AS adopter_name
FROM ANIMAL a
JOIN  KENNEL k ON a.kennel_ID = k.kennel_ID
LEFT JOIN TREATMENT_RECORD tr ON a.animal_ID = tr.animal_ID
LEFT JOIN TREATMENT t ON tr.treatment_ID = t.treatment_ID
LEFT JOIN STAFF s ON tr.staff_ID = s.staff_ID
LEFT JOIN ADOPTION adp ON a.animal_ID = adp.animal_ID
LEFT JOIN ADOPTER ad ON adp.adopter_ID = ad.adopter_ID
ORDER BY a.animal_ID;

-- =============================================================================
-- END OF SCRIPT
-- =============================================================================
