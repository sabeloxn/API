# Using lightweight alpine image
FROM python:3.11-alpine

# Installing packages
RUN apk update
RUN pip install --no-cache-dir pipenv

# Defining working directory and adding source code
WORKDIR /usr/src/app
COPY Pipfile Pipfile.lock bootstrap.sh ./
COPY cashman ./cashman

# Install API dependencies
RUN pipenv install --system --deploy 
RUN pipenv --python /usr/local/bin/python3
# Start app
EXPOSE 5000
ENTRYPOINT ["/usr/src/app/bootstrap.sh"]