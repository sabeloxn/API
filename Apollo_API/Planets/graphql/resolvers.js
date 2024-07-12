const planets = require('../models/planets');

module.exports = {
    Query: {
            async planet(_,{ID}) {
                return await planets.findById(ID)
            },
            async planets() {
                return await planets.find()
            },
        }
    }