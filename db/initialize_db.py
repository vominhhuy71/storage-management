import mysql.connector
import hashlib


mydb = mysql.connector.connect(
  host="localhost",
  user="root",
  password="ourpassword",
  database = "storage_management"
)


mycursor = mydb.cursor()

#CREATE TABLE 
#mycursor.execute("CREATE TABLE items (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(255), quantity INT, unit VARCHAR(255))") 

#Initialize
sql = "INSERT INTO items (name, quantity, unit) VALUES (%s, %s, %s)"
val = ("Milk", 3, "liters")
mycursor.execute(sql, val)
mydb.commit()
mycursor.close()




