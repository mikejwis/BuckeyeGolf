
module.exports = {
  entry: {
    'polyfills': './src/polyfills.browser.ts',
    'vendor':    './src/vendor.browser.ts',
    'main':       './src/main.browser.ts',
  },
  mode: 'development',
  output: {
    filename: '[name].bundle.js',
    sourceMapFilename: '[name].map',
    chunkFilename: '[id].chunk.js'
  },
  module:{
      rules: [
          {
              test: /.ts$/,
              use: 'ts-loader'
          }
      ]
  }
}