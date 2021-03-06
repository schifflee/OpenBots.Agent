/* 
 * OpenBots Server API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = OpenBots.Service.API.Client.SwaggerDateConverter;

namespace OpenBots.Service.API.Model
{
    /// <summary>
    /// QueueItem
    /// </summary>
    [DataContract]
        public partial class QueueItem :  IEquatable<QueueItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueItem" /> class.
        /// </summary>
        /// <param name="organizationId">organizationId.</param>
        /// <param name="processID">processID.</param>
        /// <param name="name">name (required).</param>
        /// <param name="subtopic">subtopic.</param>
        /// <param name="_event">_event.</param>
        /// <param name="source">source.</param>
        /// <param name="priority">priority (default to 1).</param>
        /// <param name="queueItemType">queueItemType.</param>
        /// <param name="entityType">entityType.</param>
        /// <param name="entityStatus">entityStatus.</param>
        /// <param name="dataJSON">dataJSON.</param>
        /// <param name="dataText">dataText.</param>
        /// <param name="dontDequeueUntil">dontDequeueUntil.</param>
        /// <param name="dontDequeueAfter">dontDequeueAfter.</param>
        /// <param name="isDequeued">isDequeued (default to false).</param>
        /// <param name="isLocked">isLocked (default to false).</param>
        /// <param name="lockedOn">lockedOn.</param>
        /// <param name="lockedUntil">lockedUntil.</param>
        /// <param name="lockedBy">lockedBy.</param>
        /// <param name="lockTransactionKey">lockTransactionKey.</param>
        /// <param name="retryCount">retryCount.</param>
        /// <param name="lastOccuredError">lastOccuredError.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="isError">isError (default to false).</param>
        /// <param name="queueID">queueID.</param>
        /// <param name="data">data.</param>
        /// <param name="rawData">rawData.</param>
        /// <param name="status">status.</param>
        /// <param name="statusMessage">statusMessage.</param>
        /// <param name="exceptionMessage">exceptionMessage.</param>
        /// <param name="id">id.</param>
        /// <param name="isDeleted">isDeleted (default to false).</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="deletedBy">deletedBy.</param>
        /// <param name="deleteOn">deleteOn.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="updatedBy">updatedBy.</param>
        public QueueItem(Guid? organizationId = default(Guid?), Guid? processID = default(Guid?), string name = default(string), string subtopic = default(string), string _event = default(string), string source = default(string), int? priority = 1, string queueItemType = default(string), string entityType = default(string), string entityStatus = default(string), string dataJSON = default(string), string dataText = default(string), DateTime? dontDequeueUntil = default(DateTime?), DateTime? dontDequeueAfter = default(DateTime?), bool? isDequeued = false, bool? isLocked = false, DateTime? lockedOn = default(DateTime?), DateTime? lockedUntil = default(DateTime?), Guid? lockedBy = default(Guid?), Guid? lockTransactionKey = default(Guid?), int? retryCount = default(int?), string lastOccuredError = default(string), byte[] timestamp = default(byte[]), bool? isError = false, Guid? queueID = default(Guid?), string data = default(string), string rawData = default(string), string status = default(string), string statusMessage = default(string), string exceptionMessage = default(string), Guid? id = default(Guid?), bool? isDeleted = false, string createdBy = default(string), DateTime? createdOn = default(DateTime?), string deletedBy = default(string), DateTime? deleteOn = default(DateTime?), DateTime? updatedOn = default(DateTime?), string updatedBy = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for QueueItem and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.OrganizationId = organizationId;
            this.ProcessID = processID;
            this.Subtopic = subtopic;
            this.Event = _event;
            this.Source = source;
            // use default value if no "priority" provided
            if (priority == null)
            {
                this.Priority = 1;
            }
            else
            {
                this.Priority = priority;
            }
            this.QueueItemType = queueItemType;
            this.EntityType = entityType;
            this.EntityStatus = entityStatus;
            this.DataJSON = dataJSON;
            this.DataText = dataText;
            this.DontDequeueUntil = dontDequeueUntil;
            this.DontDequeueAfter = dontDequeueAfter;
            // use default value if no "isDequeued" provided
            if (isDequeued == null)
            {
                this.IsDequeued = false;
            }
            else
            {
                this.IsDequeued = isDequeued;
            }
            // use default value if no "isLocked" provided
            if (isLocked == null)
            {
                this.IsLocked = false;
            }
            else
            {
                this.IsLocked = isLocked;
            }
            this.LockedOn = lockedOn;
            this.LockedUntil = lockedUntil;
            this.LockedBy = lockedBy;
            this.LockTransactionKey = lockTransactionKey;
            this.RetryCount = retryCount;
            this.LastOccuredError = lastOccuredError;
            this.Timestamp = timestamp;
            // use default value if no "isError" provided
            if (isError == null)
            {
                this.IsError = false;
            }
            else
            {
                this.IsError = isError;
            }
            this.QueueID = queueID;
            this.Data = data;
            this.RawData = rawData;
            this.Status = status;
            this.StatusMessage = statusMessage;
            this.ExceptionMessage = exceptionMessage;
            this.Id = id;
            // use default value if no "isDeleted" provided
            if (isDeleted == null)
            {
                this.IsDeleted = false;
            }
            else
            {
                this.IsDeleted = isDeleted;
            }
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.DeletedBy = deletedBy;
            this.DeleteOn = deleteOn;
            this.UpdatedOn = updatedOn;
            this.UpdatedBy = updatedBy;
        }
        
        /// <summary>
        /// Gets or Sets OrganizationId
        /// </summary>
        [DataMember(Name="organizationId", EmitDefaultValue=false)]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Gets or Sets ProcessID
        /// </summary>
        [DataMember(Name="processID", EmitDefaultValue=false)]
        public Guid? ProcessID { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Subtopic
        /// </summary>
        [DataMember(Name="subtopic", EmitDefaultValue=false)]
        public string Subtopic { get; set; }

        /// <summary>
        /// Gets or Sets Event
        /// </summary>
        [DataMember(Name="event", EmitDefaultValue=false)]
        public string Event { get; set; }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name="source", EmitDefaultValue=false)]
        public string Source { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name="priority", EmitDefaultValue=false)]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or Sets QueueItemType
        /// </summary>
        [DataMember(Name="queueItemType", EmitDefaultValue=false)]
        public string QueueItemType { get; set; }

        /// <summary>
        /// Gets or Sets EntityType
        /// </summary>
        [DataMember(Name="entityType", EmitDefaultValue=false)]
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or Sets EntityStatus
        /// </summary>
        [DataMember(Name="entityStatus", EmitDefaultValue=false)]
        public string EntityStatus { get; set; }

        /// <summary>
        /// Gets or Sets DataJSON
        /// </summary>
        [DataMember(Name="dataJSON", EmitDefaultValue=false)]
        public string DataJSON { get; set; }

        /// <summary>
        /// Gets or Sets DataText
        /// </summary>
        [DataMember(Name="dataText", EmitDefaultValue=false)]
        public string DataText { get; set; }

        /// <summary>
        /// Gets or Sets DontDequeueUntil
        /// </summary>
        [DataMember(Name="dontDequeueUntil", EmitDefaultValue=false)]
        public DateTime? DontDequeueUntil { get; set; }

        /// <summary>
        /// Gets or Sets DontDequeueAfter
        /// </summary>
        [DataMember(Name="dontDequeueAfter", EmitDefaultValue=false)]
        public DateTime? DontDequeueAfter { get; set; }

        /// <summary>
        /// Gets or Sets IsDequeued
        /// </summary>
        [DataMember(Name="isDequeued", EmitDefaultValue=false)]
        public bool? IsDequeued { get; set; }

        /// <summary>
        /// Gets or Sets IsLocked
        /// </summary>
        [DataMember(Name="isLocked", EmitDefaultValue=false)]
        public bool? IsLocked { get; set; }

        /// <summary>
        /// Gets or Sets LockedOn
        /// </summary>
        [DataMember(Name="lockedOn", EmitDefaultValue=false)]
        public DateTime? LockedOn { get; set; }

        /// <summary>
        /// Gets or Sets LockedUntil
        /// </summary>
        [DataMember(Name="lockedUntil", EmitDefaultValue=false)]
        public DateTime? LockedUntil { get; set; }

        /// <summary>
        /// Gets or Sets LockedBy
        /// </summary>
        [DataMember(Name="lockedBy", EmitDefaultValue=false)]
        public Guid? LockedBy { get; set; }

        /// <summary>
        /// Gets or Sets LockTransactionKey
        /// </summary>
        [DataMember(Name="lockTransactionKey", EmitDefaultValue=false)]
        public Guid? LockTransactionKey { get; set; }

        /// <summary>
        /// Gets or Sets RetryCount
        /// </summary>
        [DataMember(Name="retryCount", EmitDefaultValue=false)]
        public int? RetryCount { get; set; }

        /// <summary>
        /// Gets or Sets LastOccuredError
        /// </summary>
        [DataMember(Name="lastOccuredError", EmitDefaultValue=false)]
        public string LastOccuredError { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public byte[] Timestamp { get; set; }

        /// <summary>
        /// Gets or Sets IsError
        /// </summary>
        [DataMember(Name="isError", EmitDefaultValue=false)]
        public bool? IsError { get; set; }

        /// <summary>
        /// Gets or Sets QueueID
        /// </summary>
        [DataMember(Name="queueID", EmitDefaultValue=false)]
        public Guid? QueueID { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name="data", EmitDefaultValue=false)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets RawData
        /// </summary>
        [DataMember(Name="rawData", EmitDefaultValue=false)]
        public string RawData { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets StatusMessage
        /// </summary>
        [DataMember(Name="statusMessage", EmitDefaultValue=false)]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or Sets ExceptionMessage
        /// </summary>
        [DataMember(Name="exceptionMessage", EmitDefaultValue=false)]
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets IsDeleted
        /// </summary>
        [DataMember(Name="isDeleted", EmitDefaultValue=false)]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name="createdOn", EmitDefaultValue=false)]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets DeletedBy
        /// </summary>
        [DataMember(Name="deletedBy", EmitDefaultValue=false)]
        public string DeletedBy { get; set; }

        /// <summary>
        /// Gets or Sets DeleteOn
        /// </summary>
        [DataMember(Name="deleteOn", EmitDefaultValue=false)]
        public DateTime? DeleteOn { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedOn
        /// </summary>
        [DataMember(Name="updatedOn", EmitDefaultValue=false)]
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedBy
        /// </summary>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QueueItem {\n");
            sb.Append("  OrganizationId: ").Append(OrganizationId).Append("\n");
            sb.Append("  ProcessID: ").Append(ProcessID).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Subtopic: ").Append(Subtopic).Append("\n");
            sb.Append("  Event: ").Append(Event).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  QueueItemType: ").Append(QueueItemType).Append("\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("  EntityStatus: ").Append(EntityStatus).Append("\n");
            sb.Append("  DataJSON: ").Append(DataJSON).Append("\n");
            sb.Append("  DataText: ").Append(DataText).Append("\n");
            sb.Append("  DontDequeueUntil: ").Append(DontDequeueUntil).Append("\n");
            sb.Append("  DontDequeueAfter: ").Append(DontDequeueAfter).Append("\n");
            sb.Append("  IsDequeued: ").Append(IsDequeued).Append("\n");
            sb.Append("  IsLocked: ").Append(IsLocked).Append("\n");
            sb.Append("  LockedOn: ").Append(LockedOn).Append("\n");
            sb.Append("  LockedUntil: ").Append(LockedUntil).Append("\n");
            sb.Append("  LockedBy: ").Append(LockedBy).Append("\n");
            sb.Append("  LockTransactionKey: ").Append(LockTransactionKey).Append("\n");
            sb.Append("  RetryCount: ").Append(RetryCount).Append("\n");
            sb.Append("  LastOccuredError: ").Append(LastOccuredError).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  IsError: ").Append(IsError).Append("\n");
            sb.Append("  QueueID: ").Append(QueueID).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  RawData: ").Append(RawData).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StatusMessage: ").Append(StatusMessage).Append("\n");
            sb.Append("  ExceptionMessage: ").Append(ExceptionMessage).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsDeleted: ").Append(IsDeleted).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  DeletedBy: ").Append(DeletedBy).Append("\n");
            sb.Append("  DeleteOn: ").Append(DeleteOn).Append("\n");
            sb.Append("  UpdatedOn: ").Append(UpdatedOn).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as QueueItem);
        }

        /// <summary>
        /// Returns true if QueueItem instances are equal
        /// </summary>
        /// <param name="input">Instance of QueueItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QueueItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OrganizationId == input.OrganizationId ||
                    (this.OrganizationId != null &&
                    this.OrganizationId.Equals(input.OrganizationId))
                ) && 
                (
                    this.ProcessID == input.ProcessID ||
                    (this.ProcessID != null &&
                    this.ProcessID.Equals(input.ProcessID))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Subtopic == input.Subtopic ||
                    (this.Subtopic != null &&
                    this.Subtopic.Equals(input.Subtopic))
                ) && 
                (
                    this.Event == input.Event ||
                    (this.Event != null &&
                    this.Event.Equals(input.Event))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.Priority == input.Priority ||
                    (this.Priority != null &&
                    this.Priority.Equals(input.Priority))
                ) && 
                (
                    this.QueueItemType == input.QueueItemType ||
                    (this.QueueItemType != null &&
                    this.QueueItemType.Equals(input.QueueItemType))
                ) && 
                (
                    this.EntityType == input.EntityType ||
                    (this.EntityType != null &&
                    this.EntityType.Equals(input.EntityType))
                ) && 
                (
                    this.EntityStatus == input.EntityStatus ||
                    (this.EntityStatus != null &&
                    this.EntityStatus.Equals(input.EntityStatus))
                ) && 
                (
                    this.DataJSON == input.DataJSON ||
                    (this.DataJSON != null &&
                    this.DataJSON.Equals(input.DataJSON))
                ) && 
                (
                    this.DataText == input.DataText ||
                    (this.DataText != null &&
                    this.DataText.Equals(input.DataText))
                ) && 
                (
                    this.DontDequeueUntil == input.DontDequeueUntil ||
                    (this.DontDequeueUntil != null &&
                    this.DontDequeueUntil.Equals(input.DontDequeueUntil))
                ) && 
                (
                    this.DontDequeueAfter == input.DontDequeueAfter ||
                    (this.DontDequeueAfter != null &&
                    this.DontDequeueAfter.Equals(input.DontDequeueAfter))
                ) && 
                (
                    this.IsDequeued == input.IsDequeued ||
                    (this.IsDequeued != null &&
                    this.IsDequeued.Equals(input.IsDequeued))
                ) && 
                (
                    this.IsLocked == input.IsLocked ||
                    (this.IsLocked != null &&
                    this.IsLocked.Equals(input.IsLocked))
                ) && 
                (
                    this.LockedOn == input.LockedOn ||
                    (this.LockedOn != null &&
                    this.LockedOn.Equals(input.LockedOn))
                ) && 
                (
                    this.LockedUntil == input.LockedUntil ||
                    (this.LockedUntil != null &&
                    this.LockedUntil.Equals(input.LockedUntil))
                ) && 
                (
                    this.LockedBy == input.LockedBy ||
                    (this.LockedBy != null &&
                    this.LockedBy.Equals(input.LockedBy))
                ) && 
                (
                    this.LockTransactionKey == input.LockTransactionKey ||
                    (this.LockTransactionKey != null &&
                    this.LockTransactionKey.Equals(input.LockTransactionKey))
                ) && 
                (
                    this.RetryCount == input.RetryCount ||
                    (this.RetryCount != null &&
                    this.RetryCount.Equals(input.RetryCount))
                ) && 
                (
                    this.LastOccuredError == input.LastOccuredError ||
                    (this.LastOccuredError != null &&
                    this.LastOccuredError.Equals(input.LastOccuredError))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
                ) && 
                (
                    this.IsError == input.IsError ||
                    (this.IsError != null &&
                    this.IsError.Equals(input.IsError))
                ) && 
                (
                    this.QueueID == input.QueueID ||
                    (this.QueueID != null &&
                    this.QueueID.Equals(input.QueueID))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.RawData == input.RawData ||
                    (this.RawData != null &&
                    this.RawData.Equals(input.RawData))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.StatusMessage == input.StatusMessage ||
                    (this.StatusMessage != null &&
                    this.StatusMessage.Equals(input.StatusMessage))
                ) && 
                (
                    this.ExceptionMessage == input.ExceptionMessage ||
                    (this.ExceptionMessage != null &&
                    this.ExceptionMessage.Equals(input.ExceptionMessage))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.IsDeleted == input.IsDeleted ||
                    (this.IsDeleted != null &&
                    this.IsDeleted.Equals(input.IsDeleted))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.CreatedOn == input.CreatedOn ||
                    (this.CreatedOn != null &&
                    this.CreatedOn.Equals(input.CreatedOn))
                ) && 
                (
                    this.DeletedBy == input.DeletedBy ||
                    (this.DeletedBy != null &&
                    this.DeletedBy.Equals(input.DeletedBy))
                ) && 
                (
                    this.DeleteOn == input.DeleteOn ||
                    (this.DeleteOn != null &&
                    this.DeleteOn.Equals(input.DeleteOn))
                ) && 
                (
                    this.UpdatedOn == input.UpdatedOn ||
                    (this.UpdatedOn != null &&
                    this.UpdatedOn.Equals(input.UpdatedOn))
                ) && 
                (
                    this.UpdatedBy == input.UpdatedBy ||
                    (this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(input.UpdatedBy))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OrganizationId != null)
                    hashCode = hashCode * 59 + this.OrganizationId.GetHashCode();
                if (this.ProcessID != null)
                    hashCode = hashCode * 59 + this.ProcessID.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Subtopic != null)
                    hashCode = hashCode * 59 + this.Subtopic.GetHashCode();
                if (this.Event != null)
                    hashCode = hashCode * 59 + this.Event.GetHashCode();
                if (this.Source != null)
                    hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.Priority != null)
                    hashCode = hashCode * 59 + this.Priority.GetHashCode();
                if (this.QueueItemType != null)
                    hashCode = hashCode * 59 + this.QueueItemType.GetHashCode();
                if (this.EntityType != null)
                    hashCode = hashCode * 59 + this.EntityType.GetHashCode();
                if (this.EntityStatus != null)
                    hashCode = hashCode * 59 + this.EntityStatus.GetHashCode();
                if (this.DataJSON != null)
                    hashCode = hashCode * 59 + this.DataJSON.GetHashCode();
                if (this.DataText != null)
                    hashCode = hashCode * 59 + this.DataText.GetHashCode();
                if (this.DontDequeueUntil != null)
                    hashCode = hashCode * 59 + this.DontDequeueUntil.GetHashCode();
                if (this.DontDequeueAfter != null)
                    hashCode = hashCode * 59 + this.DontDequeueAfter.GetHashCode();
                if (this.IsDequeued != null)
                    hashCode = hashCode * 59 + this.IsDequeued.GetHashCode();
                if (this.IsLocked != null)
                    hashCode = hashCode * 59 + this.IsLocked.GetHashCode();
                if (this.LockedOn != null)
                    hashCode = hashCode * 59 + this.LockedOn.GetHashCode();
                if (this.LockedUntil != null)
                    hashCode = hashCode * 59 + this.LockedUntil.GetHashCode();
                if (this.LockedBy != null)
                    hashCode = hashCode * 59 + this.LockedBy.GetHashCode();
                if (this.LockTransactionKey != null)
                    hashCode = hashCode * 59 + this.LockTransactionKey.GetHashCode();
                if (this.RetryCount != null)
                    hashCode = hashCode * 59 + this.RetryCount.GetHashCode();
                if (this.LastOccuredError != null)
                    hashCode = hashCode * 59 + this.LastOccuredError.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
                if (this.IsError != null)
                    hashCode = hashCode * 59 + this.IsError.GetHashCode();
                if (this.QueueID != null)
                    hashCode = hashCode * 59 + this.QueueID.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
                if (this.RawData != null)
                    hashCode = hashCode * 59 + this.RawData.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.StatusMessage != null)
                    hashCode = hashCode * 59 + this.StatusMessage.GetHashCode();
                if (this.ExceptionMessage != null)
                    hashCode = hashCode * 59 + this.ExceptionMessage.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.IsDeleted != null)
                    hashCode = hashCode * 59 + this.IsDeleted.GetHashCode();
                if (this.CreatedBy != null)
                    hashCode = hashCode * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hashCode = hashCode * 59 + this.CreatedOn.GetHashCode();
                if (this.DeletedBy != null)
                    hashCode = hashCode * 59 + this.DeletedBy.GetHashCode();
                if (this.DeleteOn != null)
                    hashCode = hashCode * 59 + this.DeleteOn.GetHashCode();
                if (this.UpdatedOn != null)
                    hashCode = hashCode * 59 + this.UpdatedOn.GetHashCode();
                if (this.UpdatedBy != null)
                    hashCode = hashCode * 59 + this.UpdatedBy.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
