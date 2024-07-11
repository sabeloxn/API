# blog/schema.py
import graphene
import requests 
from graphene_django import DjangoObjectType

from .models import Food

class FoodType(DjangoObjectType):
    class Meta:
        model = Food
        fields = "__all__"

class Query(graphene.ObjectType):
    food_list = graphene.List(FoodType)

    def resolve_posts(self, info):
        return Food.objects.all()

    def resolve_authors(self, info):
        """
        The resolve_authors function is a resolver. It’s responsible for retrieving the data that will be returned as part of an execution result.

        :param self: Pass the instance of the object to be used
        :param info: Pass information about the query to the resolver
        :return: A list of all the authors in the database
        """
        return Food.objects.all()
    
class SearchFood(graphene.Mutation):
    class Arguments:
        search_string = graphene.String(required=True)
    food = graphene.Field(FoodType)

    def mutate(self, info, search_string):
        food_name="oatmeal"#unused
        url = f"https://api.nal.usda.gov/fdc/v1/foods/search?query={search_string}"

        headers = {'X-Api-Key': 'uPepNCcg14kQ99wysRCNRiRxL5BX9tarAosGsmu9'}
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

                print(label_nutrient_name,": ", label_nutrient_value,label_nutrient_unit_name) #,"\n"
                #print(label_nutrient_name)
            print("\nINGRIDIENTS: ",food_ingredients )
            #print("fdcId: %s Name: %s Serving Size: %s \n" %(food_fdcid, food_name, serving_size))
            #print(label_nutrients)
            #print(label_nutrient_name)
            res+=1

class Mutation(graphene.ObjectType):
    create_post = SearchFood.Field()


schema = graphene.Schema(query=Query, mutation=Mutation)