CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';


CREATE TABLE chores(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255),
  isComplete BOOLEAN DEFAULT false,
  timeToComplete SMALLINT UNSIGNED NOT NULL
) DEFAULT charset utf8mb4 COMMENT '';


INSERT INTO 
  chores(name, description, isComplete, timeToComplete)
VALUES
  ('Feed Animals', 'They will go hungry without being fed', false, 10);

  DELETE FROM chores
  WHERE 
  id = 1;

  SELECT
  *
  FROM
  chores;

  UPDATE chores
  SET
  `isComplete` = true
  WHERE
  name = 'Feed Animals';
