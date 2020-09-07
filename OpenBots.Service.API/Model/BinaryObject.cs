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
    /// Binary Object data model
    /// </summary>
    [DataContract]
        public partial class BinaryObject :  IEquatable<BinaryObject>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryObject" /> class.
        /// </summary>
        /// <param name="organizationId">Organization Id.</param>
        /// <param name="contentType">Content Type.</param>
        /// <param name="correlationEntityId">Correlation Identity Id.</param>
        /// <param name="correlationEntity">Correlation Identity.</param>
        /// <param name="storagePath">Storage Path.</param>
        /// <param name="storageProvider">Storage Provider.</param>
        /// <param name="sizeInBytes">Size in Bytes.</param>
        /// <param name="hashCode">Hash Code.</param>
        /// <param name="name">name (required).</param>
        /// <param name="id">id.</param>
        /// <param name="isDeleted">isDeleted (default to false).</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="createdOn">createdOn.</param>
        /// <param name="deletedBy">deletedBy.</param>
        /// <param name="deleteOn">deleteOn.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="updatedOn">updatedOn.</param>
        /// <param name="updatedBy">updatedBy.</param>
        public BinaryObject(Guid? organizationId = default(Guid?), string contentType = default(string), Guid? correlationEntityId = default(Guid?), string correlationEntity = default(string), string storagePath = default(string), string storageProvider = default(string), long? sizeInBytes = default(long?), string hashCode = default(string), string name = default(string), Guid? id = default(Guid?), bool? isDeleted = false, string createdBy = default(string), DateTime? createdOn = default(DateTime?), string deletedBy = default(string), DateTime? deleteOn = default(DateTime?), byte[] timestamp = default(byte[]), DateTime? updatedOn = default(DateTime?), string updatedBy = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for BinaryObject and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            this.OrganizationId = organizationId;
            this.ContentType = contentType;
            this.CorrelationEntityId = correlationEntityId;
            this.CorrelationEntity = correlationEntity;
            this.StoragePath = storagePath;
            this.StorageProvider = storageProvider;
            this.SizeInBytes = sizeInBytes;
            this.HashCode = hashCode;
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
            this.Timestamp = timestamp;
            this.UpdatedOn = updatedOn;
            this.UpdatedBy = updatedBy;
        }
        
        /// <summary>
        /// Organization Id
        /// </summary>
        /// <value>Organization Id</value>
        [DataMember(Name="organizationId", EmitDefaultValue=false)]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Content Type
        /// </summary>
        /// <value>Content Type</value>
        [DataMember(Name="contentType", EmitDefaultValue=false)]
        public string ContentType { get; set; }

        /// <summary>
        /// Correlation Identity Id
        /// </summary>
        /// <value>Correlation Identity Id</value>
        [DataMember(Name="correlationEntityId", EmitDefaultValue=false)]
        public Guid? CorrelationEntityId { get; set; }

        /// <summary>
        /// Correlation Identity
        /// </summary>
        /// <value>Correlation Identity</value>
        [DataMember(Name="correlationEntity", EmitDefaultValue=false)]
        public string CorrelationEntity { get; set; }

        /// <summary>
        /// Storage Path
        /// </summary>
        /// <value>Storage Path</value>
        [DataMember(Name="storagePath", EmitDefaultValue=false)]
        public string StoragePath { get; set; }

        /// <summary>
        /// Storage Provider
        /// </summary>
        /// <value>Storage Provider</value>
        [DataMember(Name="storageProvider", EmitDefaultValue=false)]
        public string StorageProvider { get; set; }

        /// <summary>
        /// Size in Bytes
        /// </summary>
        /// <value>Size in Bytes</value>
        [DataMember(Name="sizeInBytes", EmitDefaultValue=false)]
        public long? SizeInBytes { get; set; }

        /// <summary>
        /// Hash Code
        /// </summary>
        /// <value>Hash Code</value>
        [DataMember(Name="hashCode", EmitDefaultValue=false)]
        public string HashCode { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

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
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public byte[] Timestamp { get; set; }

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
            sb.Append("class BinaryObject {\n");
            sb.Append("  OrganizationId: ").Append(OrganizationId).Append("\n");
            sb.Append("  ContentType: ").Append(ContentType).Append("\n");
            sb.Append("  CorrelationEntityId: ").Append(CorrelationEntityId).Append("\n");
            sb.Append("  CorrelationEntity: ").Append(CorrelationEntity).Append("\n");
            sb.Append("  StoragePath: ").Append(StoragePath).Append("\n");
            sb.Append("  StorageProvider: ").Append(StorageProvider).Append("\n");
            sb.Append("  SizeInBytes: ").Append(SizeInBytes).Append("\n");
            sb.Append("  HashCode: ").Append(HashCode).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsDeleted: ").Append(IsDeleted).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  DeletedBy: ").Append(DeletedBy).Append("\n");
            sb.Append("  DeleteOn: ").Append(DeleteOn).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
            return this.Equals(input as BinaryObject);
        }

        /// <summary>
        /// Returns true if BinaryObject instances are equal
        /// </summary>
        /// <param name="input">Instance of BinaryObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BinaryObject input)
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
                    this.ContentType == input.ContentType ||
                    (this.ContentType != null &&
                    this.ContentType.Equals(input.ContentType))
                ) && 
                (
                    this.CorrelationEntityId == input.CorrelationEntityId ||
                    (this.CorrelationEntityId != null &&
                    this.CorrelationEntityId.Equals(input.CorrelationEntityId))
                ) && 
                (
                    this.CorrelationEntity == input.CorrelationEntity ||
                    (this.CorrelationEntity != null &&
                    this.CorrelationEntity.Equals(input.CorrelationEntity))
                ) && 
                (
                    this.StoragePath == input.StoragePath ||
                    (this.StoragePath != null &&
                    this.StoragePath.Equals(input.StoragePath))
                ) && 
                (
                    this.StorageProvider == input.StorageProvider ||
                    (this.StorageProvider != null &&
                    this.StorageProvider.Equals(input.StorageProvider))
                ) && 
                (
                    this.SizeInBytes == input.SizeInBytes ||
                    (this.SizeInBytes != null &&
                    this.SizeInBytes.Equals(input.SizeInBytes))
                ) && 
                (
                    this.HashCode == input.HashCode ||
                    (this.HashCode != null &&
                    this.HashCode.Equals(input.HashCode))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
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
                if (this.ContentType != null)
                    hashCode = hashCode * 59 + this.ContentType.GetHashCode();
                if (this.CorrelationEntityId != null)
                    hashCode = hashCode * 59 + this.CorrelationEntityId.GetHashCode();
                if (this.CorrelationEntity != null)
                    hashCode = hashCode * 59 + this.CorrelationEntity.GetHashCode();
                if (this.StoragePath != null)
                    hashCode = hashCode * 59 + this.StoragePath.GetHashCode();
                if (this.StorageProvider != null)
                    hashCode = hashCode * 59 + this.StorageProvider.GetHashCode();
                if (this.SizeInBytes != null)
                    hashCode = hashCode * 59 + this.SizeInBytes.GetHashCode();
                if (this.HashCode != null)
                    hashCode = hashCode * 59 + this.HashCode.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
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
