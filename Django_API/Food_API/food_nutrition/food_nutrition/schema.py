# core/schema.py
import graphene

import food_nutrition_app.schema
class Query(food_nutrition_app.schema.Query,  graphene.ObjectType): #users.schema.Query,
    # Combine the queries from different apps
    pass
class Mutation(food_nutrition_app.schema.Mutation, graphene.ObjectType):
    # Combine the mutations from different apps
    pass

schema = graphene.Schema(query=Query, mutation=Mutation)