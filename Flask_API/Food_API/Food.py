
# import requests module 
import requests 

# Making a get request 
# food_id=534358 #one food
# url = f"https://api.nal.usda.gov/fdc/v1/food/{food_id}?" #one food

food_name="oatmeal"
url = f"https://api.nal.usda.gov/fdc/v1/foods/search?query={food_name}"

headers = {'X-Api-Key': ''}
r = requests.get(url, headers=headers)

response = requests.get(url,headers=headers) 
# print response 
print(response) 
print()

#//---------------------------------------------------------------------------------+
#//Convert Request Response to Dictionary                                           +
#//---------------------------------------------------------------------------------+

# Store JSON data in API_Data 
API_Data = response.json() 
#print(API_Data["description"]) #one food

#label_nutrients_data = API_Data["labelNutrients"]#one food

res = 0
for i in (API_Data):
    food_name = API_Data["foods"][res]["description"]
    #Some fields don't have "brandName", it is captured in dataType
    datatype = API_Data["foods"][res]["dataType"]
    if datatype == "Branded":
        food_brand_name = API_Data["foods"][res]["brandName"]

    food_fdcid = API_Data["foods"][res]["fdcId"]
    #Some fields don't have "servingSize", have to check for key. Also if there is no serving size , there is no serving size unit.
    if "servingSize" in API_Data["foods"][res]:
        serving_size = API_Data["foods"][res]["servingSize"]
        serving_size_unit = API_Data["foods"][res]["servingSizeUnit"]

    if "ingredients" in API_Data["foods"][res]:
        food_ingredients = API_Data["foods"][res]["ingredients"]
    print()
    print("fdcId: %s Desc: %s Brand Name: %s Serving Size: %s%s \n" %(food_fdcid, food_name,food_brand_name, serving_size,serving_size_unit))
    
    for j in range (len(API_Data["foods"][res]["foodNutrients"])):
        label_nutrients = API_Data["foods"][res]["foodNutrients"]#["nutrientName"]
        label_nutrient_name = label_nutrients[j]["nutrientName"]
        label_nutrient_value = label_nutrients[j]["value"]
        label_nutrient_unit_name = label_nutrients[j]["unitName"]

        #print(label_nutrient_name,": ", label_nutrient_value,label_nutrient_unit_name) #,"\n"
        print(label_nutrient_name)
    print("\nINGRIDIENTS: ",food_ingredients )
    #print("fdcId: %s Name: %s Serving Size: %s \n" %(food_fdcid, food_name, serving_size))
    #print(label_nutrients)
    #print(label_nutrient_name)
    res+=1

# Print label_nutrients_data for one food
# for key in label_nutrients_data:
#     label_nutrient = key
#     label_nutrient_value = label_nutrients_data[key]["value"]

#     print(label_nutrient,":", label_nutrient_value)

#  food_name = API_Data["foods"][i]["description"]
#     food_fdcid = ["foods"][i]["fdcId"]
#     print("Name : %s Id: %s" %(food_name, food_fdcid))

# for i in range (len(API_Data["foods"])):
#     if i == 50:
#         break
#     food_name = API_Data["foods"][i]["description"]
#     food_fdcid = API_Data["foods"][i]["fdcId"]
#     serving_size = API_Data["foods"][i]["servingSize"]

#     if i < (len(API_Data["foods"][i]["foodNutrients"])):
#         label_nutrient = API_Data["foods"][i]["foodNutrients"][i]#["nutrientName"]

#     print("fdcId: %s Name: %s Serving Size: %s \n" %(food_fdcid, food_name, serving_size))
#     print(label_nutrient)
#     print()