import 'bootstrap/dist/css/bootstrap.min.css';
import React, { Component } from 'react';
import axios from 'axios';
import {Progress} from 'reactstrap';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './App.css';

class App extends Component {

  //Sets the initial state.
  constructor(props) {
    super(props);
    this.state = {
      selectedFile: null,
      loaded: 0,
      ascii: null
    };
  }

  //Checks to ensure the image is a supported extension.
  checkMimeType = (files) => {
    const types = ['image/png', 'image/jpeg', 'image/bmp']; 
    if (types.every(type => files[0].type !== type)) { 
      toast.error(files[0].type + ' is not a supported format'); 
      return false;
    }
    return true;
  }

  //Checks to ensure no more than one file has been uploaded at once
  maxSelectFile = (files) => {
    if (files.length !== 1) {
      toast.error('Only one image can be uploaded at a time.');
      return false;
    }
    return true;
  }

  //Checks files to make sure they do not exceed 4Mb.
  checkFileSize = (files) => {
    let size = 4000000;
    if (files[0].size >= size) {
      toast.error(files[0].type + 'is too large, please pick a smaller file (4Mb or less).');
      return false;
    }
    return true;    
  }

  //Recieves file data in event, checks if the file has the correct extensions and is an appropriate size, and sets it to selectedFile.
  onChange = (event) => {
    var files = event.target.files;
    if (this.maxSelectFile(files) && this.checkMimeType(files) && this.checkFileSize(files)) {
      this.setState({
        selectedFile: files,
        loaded: 0
      });
    }
    else {
      event.target.value = null;
    }
  }

  onClick = () => {
    //Takes the selected files and adds each to a key/value paired constant. 
    const data = new FormData();
    data.append('file', this.state.selectedFile[0]);
        
    //Calls the API, which converts the files to ASCII. Updates loaded, which updates progress bar.
    axios.post("./api/Image/UploadImage", data, {
      onUploadProgress: ProgressEvent => {
        this.setState({
          loaded: (ProgressEvent.loaded / ProgressEvent.total * 100),
        });
      }

    //Displays a success or fail message depending on API response.
    }).then(res => { 
      this.setState({ ascii : res.data });
      toast.success('Upload succeeded');
    }).catch(() => { 
      toast.error('Upload failed');
    });
  }

  onClickCopy = () => {
    //Selects contents of the renderfont element, which contains the ASCII. 
    var element = document.getElementsByClassName("renderfont");
    if (window.getSelection && document.createRange) { // IE 9 and non-IE

      //selects full text portion of the element.
      var range = document.createRange();
      range.selectNodeContents(element[0]);
      var band = window.getSelection();
      band.removeAllRanges();
      band.addRange(range);
    }
    else if (document.body.createTextRange) { // IE < 9
      var textRange = document.body.createTextRange();
      textRange.moveToElementText(element);
      textRange.select();
    }
    //Adds selection to clipboard.
    document.execCommand("copy");

    //Clears selection.
    if (window.getSelection) {window.getSelection().removeAllRanges();}
    else if (document.selection) {document.selection.empty();}

    //Displays a success message.
    toast.success('Copy successful');
  }

  //Renders the webpage
  render() {
    return (
    <div class="container">
      <div class="row">
        <div class="offset-md-3 col-md-6">
          <div class="form-group files">
            <label>Upload Your File </label>
            <input type="file" class="form-control" multiple onChange={this.onChange}/>
          </div>  

          <div class="form-group">
            <ToastContainer/>
            <Progress max="100" color="success" value={this.state.loaded}/>
          </div>
          <button type="button" class="btn btn-primary btn-block" onClick={this.onClick}> Upload </button>
          <br/>
          <button type="button" class="btn btn-success btn-block" onClick={this.onClickCopy}> Copy to Clipboard </button>
        </div>
      </div>
      <pre class="renderfont">{this.state.ascii}</pre>
    </div>
    );
  }
}

export default App;