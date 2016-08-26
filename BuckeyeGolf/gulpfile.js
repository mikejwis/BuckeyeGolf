/// <binding BeforeBuild='inject' />

'use strict';

var gulp = require('gulp');
var $ = require('gulp-load-plugins')({lazy:true});
var config = require('./gulp.config')();


//////// Tasks /////////////

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('images', function () {
    return gulp
        .src(config.images)
        .pipe($.imagemin())
        .pipe(gulp.dest(config.imageDest));
});

gulp.task('styles', function () {
    return gulp
        .src(config.sass)
        .pipe($.sass().on('error', $.sass.logError))
        .pipe(gulp.dest(config.contentDest));
});

gulp.task('inject',['styles', 'images'], function () {

    return gulp
        .src(config.index)
        .pipe($.inject(gulp.src(config.appJs)))
        .pipe($.inject(gulp.src(config.styles)))
        .pipe(gulp.dest(config.rootDir));
});

gulp.task('vet', function () {
    return gulp
        .src(config.allJs)
        .pipe($.jshint())
        .pipe($.jshint.reporter('jshint-stylish', {verbose:true}));

});

//////// Functions ////////

function log(msg) {
    if(typeof(msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(item[msg]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}