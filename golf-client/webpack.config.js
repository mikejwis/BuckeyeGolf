
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
              test: /\.ts$/,
              use: [
                { loader: 'ts-loader' },
                { loader: 'angular2-template-loader'}
              ]
          },
          { 
            test: /\.css$/, loaders: ['to-string-loader', 'css-loader'] 
          },
          { 
            test: /\.html$/, 
            use: 'raw-loader' 
          }
      ]
  },
  resolve:{
    extensions:['.ts','.js']
  }
}