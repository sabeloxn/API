const planets = require('../models/planets');

module.exports = {
    Query: {
            async planets(_,{}) {
                return await planets.find()
            },
        }
    }