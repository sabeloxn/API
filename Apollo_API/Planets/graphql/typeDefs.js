const { gql } = require( 'apollo-server');

module.exports = gql`

type planets {
  name: String
  orderFromSun: Int
  hasRings: Boolean
  surfaceTemperatureC: SurfaceTemperatureC
  mainAtmosphere: [String]
  _id: String
}
type SurfaceTemperatureC {
  min: String
  max: String
  mean: Float
}

#-----------------------------------------------------------------------------+
#INPUT                                                                        +
#-----------------------------------------------------------------------------+
#-----------------------------------------------------------------------------+
#QUERY                                                                        +
#-----------------------------------------------------------------------------+
type Query {
    planets(ID: ID): [planets]! 
}
#-----------------------------------------------------------------------------+
#MUTATION                                                                     +
#-----------------------------------------------------------------------------+
# type Mutation {
#-----------------------------------------------------------------------------+
#INSERT                                                                        +
#-----------------------------------------------------------------------------+
#-----------------------------------------------------------------------------+
#UPDATE                                                                        +
#-----------------------------------------------------------------------------+
#-----------------------------------------------------------------------------+
#DELETE                                                                        +
#-----------------------------------------------------------------------------+
#}
`