docker build -t candle-store-sdg .

docker tag sdg-candle-image registry.heroku.com/candle-store-sdg/web

docker push registry.heroku.com/candle-store-sdg/web

heroku container:release web -a candle-store-sdg