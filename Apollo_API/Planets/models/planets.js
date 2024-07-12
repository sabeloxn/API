const { model , Schema} = require ('mongoose')

const planetSchema = new Schema ({
        name: String,
        orderFromSun: Number,
        hasRings: Boolean,
        surfaceTemperatureC: {
            min: String,
            max: String,
            mean: Number
        },
        mainAtmosphere: [String],
        id: String
});
module. exports = model( 'planet', planetSchema);