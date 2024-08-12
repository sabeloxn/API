const { ApolloServer } = require('apollo-server') ;
const mongoose = require('mongoose');
const MONGODB = "mongodb://127.0.0.1:27017/test";

const typeDefs = require('./graphql/typeDefs.js');
const resolvers = require('./graphql/resolvers.js');

const server = new ApolloServer({
    typeDefs,
    resolvers,
});

mongoose.connect(MONGODB)
    .then(() => {
    console.log("🚀  MongoDB  Connection Successful.");
    return server.listen({port: 4000});
    })