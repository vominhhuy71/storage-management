from flask import Flask, jsonify, request, abort
import mysql.connector

app = Flask(__name__)

#Connect to database
mydb = mysql.connector.connect(
        host="localhost",
        user="root",
        password="yourpassword",
        database = "storage_management"
    )
    
#GET data from database
def fetch_data():
    cursor = mydb.cursor()
    cursor.execute("SELECT id, name, quantity, unit FROM items")
    list = cursor.fetchall()
    cursor.close()
    items= []
    
    for member in list:
        item = {
            'id': member[0],
            'name': member[1],
            'quantity': member[2],
            'unit': member[3]
        }
        items.append(item)    
    return items
    
#GET items
@app.route('/strgv1/get/all',methods = ['GET'])
def get_all():
    items = fetch_data()   
    print(items)
    return jsonify(items),200
        
#INSERT item
@app.route('/strgv1/new',methods=['POST'])
def insert_item():
    if not request.json or not 'name' in request.json:
        abort(400)
    if not request.json or not 'quantity' in request.json:
        abort(400)
    if not request.json or not 'unit' in request.json:
        abort(400)
        
    item = {
        'name':request.json['name'],
        'quantity': request.json['quantity'],
        'unit': request.json['unit']
    }
    cursor = mydb.cursor()
    sql = "INSERT INTO items (name,quantity,unit) VALUES (%s,%s)"
    val = (item.name,item.quantity,item.unit)
    cursor.execute(sql,val)
    mydb.commit()
    return 200
    
#UPDATE existing item
@app.route('/strgv1/update',methods=['PUT'])
def update_item():
    if not request.json or not 'name' in request.json:
        abort(400)
    if not request.json or not 'quantity' in request.json:
        abort(400)
    if 'quantity' in request.json and type(request.json['quantity']) is not int:
        abort(400)
    name = request.json['name']
    quantity = request.json['quantity']
    #unit = request.json['unit']
    items = fetchall()
    for item in items:
        if item[1] == name:
            cursor = mydb.cursor()
            sql = "UPDATE items SET quantity = {} WHERE name = '{}' ".format(quantity,name)
            cursor.execute(sql)
            mydb.commit()
            return 200
        else:
            abort(400)
            
#DELETE item
@app.route('/strgv1/delete/<int:id>', methods = ['DELETE'])
def delete_item(id):
    cursor = mydb.cursor()
    sql = "DELETE FROM items WHERE id = {}".format(id)
    cursor.execute(sql)
    mydb.commit()
    return 200
    
if __name__ == '__main__':

    app.run(debug=True)

