
module.exports = function () {
  var config = {
    appJs: [
      './App/**/*.module.js',
      './App/**/*.constants.js',
      './App/**/*.routes.js',
      './App/**/*.controller.js',
      './App/**/*.service.js',
      './App/**/*.*.js',
      './App/**/*.js',
      '!./App/**/*.spec.js'
    ],
    allJs: ['./App/**/*.js', './*.js'],
    index: './Index.html',
    sass: './Content/Site.scss',
    contentDest: './Content',
    imageDest: './Content/Images',
    styles: './Content/Site.css',
    images: [
      './Content/*.gif',
      './Content/*.jpg',
      './Content/*.png'
    ],
    rootDir: './'
  };

  return config;
}