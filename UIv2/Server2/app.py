from flask import Flask, jsonify, request, abort
import mysql.connector

app = Flask(__name__)

#Connect to database
mydb = mysql.connector.connect(
        host="localhost",
        user="root",
        password="ourpassword",
        database = "storage_management"
    )
    
#GET data from database
def fetch_data():
    cursor = mydb.cursor()
    cursor.execute("SELECT id, name, quantity, unit, min FROM items")
    list = cursor.fetchall()
    cursor.close()
    items= []
    
    for member in list:
        item = {
            'id': member[0],
            'itemName': member[1],
            'quantity': member[2],
            'unit': member[3],
            'min': member[4]
        }
        items.append(item)    
    return items
    

#GET items
@app.route('/strgv1/get/all',methods = ['GET'])
def get_all():
    items = fetch_data()   
    return jsonify(items),200
        
#INSERT item
@app.route('/strgv1/new',methods=['POST'])
def insert_item():
    if not request.json or not 'ItemName' in request.json:
        abort(400)
    if not request.json or not 'Quantity' in request.json:
        abort(400)
    if not request.json or not 'Unit' in request.json:
        abort(400)
        
    itemName=request.json['ItemName']
    quantity=request.json['Quantity']
    unit=request.json['Unit']
    min = request.json['Min']
    cursor = mydb.cursor()
    sql = "INSERT INTO items (name,quantity,unit,min) VALUES (%s,%s,%s,%s)"
    val = (itemName,quantity,unit,min)
    cursor.execute(sql,val)
    mydb.commit()
    return jsonify({"status":"ok"}),200
    
#UPDATE existing item
@app.route('/strgv1/update',methods=['PUT'])
def update_item():
    name = request.json['ItemName']
    quantity = request.json['Quantity']
    min = request.json['Min']
    items = fetch_data()
    found = False
    for item in items:
        if item["itemName"] == name:
            found = True
            cursor = mydb.cursor()
            sql = "UPDATE items SET quantity = {}, min = {} WHERE name = '{}' ".format(quantity,min,name)
            cursor.execute(sql)
            mydb.commit()
    if found == True:        
        return jsonify({"status":"ok"}),200
    else:
        abort(400)
            
#DELETE item
@app.route('/strgv1/delete', methods = ['DELETE'])
def delete_item():
    cursor = mydb.cursor()
    name = request.json['ItemName']
    sql = "DELETE FROM items WHERE name = '{}'".format(name)
    cursor.execute(sql)
    cursor.close()
    items = fetch_data()
    cursor = mydb.cursor()   
    cursor.execute("TRUNCATE TABLE items")
    for item in items:
        sql = "INSERT INTO items (name,quantity,unit,min) VALUES (%s,%s,%s,%s)"
        val = (item["itemName"],item["quantity"],item["unit"],item["min"])
        cursor.execute(sql,val)       
    mydb.commit()
    return jsonify({"status":"ok"}),200
    
if __name__ == '__main__':

    app.run(debug=True)

