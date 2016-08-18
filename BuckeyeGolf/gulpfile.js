/// <binding BeforeBuild='sass' />

'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('sass', function () {
    gulp.src('Content/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('Content'));
});